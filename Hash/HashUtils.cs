namespace Rko_encription.Hash
{
    internal static class HashUtils
    {
        internal static char[] GetAsciiHashTable()
        {
            List<char> asciiChars = new List<char>();

            for (int i = 0; i < Stafi.NO_OF_CHARACTERS; i++)
            {
                asciiChars.Add((char)i);
            }
            return asciiChars.ToArray();
        }

        internal static char[] GetAsciiLettersAndNumbersTable()
        {
            List<char> asciiChars = new List<char>();

            for (int i = 0; i < Stafi.NO_OF_CHARACTERS; i++)
            {
                asciiChars.Add((char)i);
            }
            return asciiChars.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray();
        }

        internal static List<char> OrderAndScrambleTable(char[] charTable, int value)
        {
            var numbers = charTable.Where(x => char.IsDigit(x)).ToList();
            var lowercase = charTable.Where(x => char.IsLower(x)).ToList();
            var uppercase = charTable.Where(x => char.IsUpper(x)).ToList();

            if (value % 2 == 0)
                return lowercase.Concat(numbers).Concat(uppercase).ToList();
            else
                return uppercase.Concat(lowercase).Concat(numbers).ToList();
        }
    }
}
