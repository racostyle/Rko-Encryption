using Rko_encription;
using System.Text;

namespace ExtensionMethods
{
    public static class HashExtensions
    {
        public static string ToHash(this string input, int length)
        {
            var value = GetInputValue(input, GetAsciiHashTable());
            var scrambledTable = ScrambleHashTable(GetAsciiLettersAndNumbersTable(), value, length);

            return scrambledTable.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next)).ToString();
        }

        private static char[] GetAsciiHashTable()
        {
            List<char> asciiChars = new List<char>();

            for (int i = 0; i < Stafi.NO_OF_CHARACTERS; i++)
            {
                asciiChars.Add((char)i);
            }
            return asciiChars.ToArray();
        }

        private static char[] GetAsciiLettersAndNumbersTable()
        {
            List<char> asciiChars = new List<char>();

            for (int i = 0; i < Stafi.NO_OF_CHARACTERS; i++)
            {
                asciiChars.Add((char)i);
            }
            return asciiChars.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray();
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

            var numbers = charTable.Where(x => char.IsDigit(x)).ToList();
            var lowercase = charTable.Where(x => char.IsLower(x)).ToList();
            var uppercase = charTable.Where(x => char.IsUpper(x)).ToList();

            if (value % 2 == 0)
                tempTable = lowercase.Concat(numbers).Concat(uppercase).ToList();
            else
                tempTable = uppercase.Concat(lowercase).Concat(numbers).ToList();

            var modulo = (length % 3) + 2;
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