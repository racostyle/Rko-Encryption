namespace Rko_encription
{
    public abstract class AEncryption
    {
        protected List<char> GetAsciiTable()
        {
            List<char> asciiChars = new List<char>();

            for (int i = 0; i < Stafi.NO_OF_CHARACTERS; i++)
            {
                asciiChars.Add((char)i);
            }
            return asciiChars;
        }

        protected char[] DecryptLoop(Dictionary<char, char> dict, char[] input)
        {       
            var result = input.Select(x => x).ToArray(); //prevents query skipping not recognized characters
            foreach (var d in dict)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Equals(d.Value)) 
                        result[i] = d.Key;
                }
            }
            return result;
        }

        protected char[] EncryptLoop(Dictionary<char, char> dict, char[] input)
        {
            
            var result = input.Select(x => x).ToArray(); //prevents query skipping not recognized characters        
            foreach (var d in dict)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Equals(d.Key)) 
                        result[i] = d.Value;
                }
            }
            return result;
        }
    }
}