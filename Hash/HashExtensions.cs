using System.Text;

namespace Rko_encription.Hash
{
    public static class HashExtensions
    {
        public static string ToHash(this string input, int length)
        {
            var value = GetInputValue(input, HashUtils.GetAsciiHashTable());
            var scrambledTable = ScrambleHashTable(HashUtils.GetAsciiLettersAndNumbersTable(), value, length);

            return scrambledTable.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next)).ToString();
        }

        public static SHashWithSalt ToHashWithSalt(this string input, int length, string salt = "")
        {
            var alphanumericTable = HashUtils.GetAsciiLettersAndNumbersTable();
            var asciiTable = HashUtils.GetAsciiHashTable();

            var random = new Random();
            if (string.IsNullOrEmpty(salt))
                salt = new string(Enumerable.Repeat(alphanumericTable, length).Select(s => s[random.Next(s.Length)]).ToArray());

            var saltValue = GetInputValue(salt, asciiTable);
            var inputValue = GetInputValue(input, asciiTable);

            var saltTable = ScrambleHashTable(alphanumericTable, saltValue, length);
            var hashTable = ScrambleHashTable(alphanumericTable, inputValue, length);

            var hash = hashTable.Zip(saltTable, (a, b) => new[] { a, b }).SelectMany(x => x).ToList();

            return new SHashWithSalt
            {
                Hash = hash.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next)).ToString().Substring(length),
                Salt = salt
            };
        }

        private static int GetInputValue(string input, char[] charTable)
        {
            int value = 0;

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < charTable.Length; j++)
                {
                    if (charTable[j] == input[i])
                        value += j + i;
                }
            }
            return value;
        }

        private static char[] ScrambleHashTable(char[] charTable, int value, int length)
        {
            List<char> tempTable;
            tempTable = HashUtils.OrderAndScrambleTable(charTable, value);

            var modulo = length % 3 + 2;
            tempTable = tempTable.Where((item, index) => index % modulo == 1).Concat(tempTable).Distinct().ToList();

            List<char> scrambledTable = new List<char>();

            int offset = length;
            int index = 0;

            while (scrambledTable.Count < length)
            {
                index += value + offset;
                while (index > tempTable.Count - 1)
                    index -= tempTable.Count;

                scrambledTable.Add(tempTable[index]);
                offset = (offset + 1) % 5;
            }
            return scrambledTable.ToArray();
        }
    }
}