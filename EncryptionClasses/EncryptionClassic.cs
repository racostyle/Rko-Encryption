using System.Text;

namespace Rko_encription
{
    public class EncryptionClassic : AEncryption, IEncryption
    {

        private Dictionary<char, char> _table;
        private int _key;

        public EncryptionClassic(int key)
        {
            _table = CreateDictTable(key);
            _key = key;
        }

        public SEncriptionResult Encrypt(string data)
        {    
            _table = CreateDictTable(_key);

            var input = data.ToCharArray();
            var result = EncryptLoop(_table, input);

            var output = result.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next));

            return new SEncriptionResult { Result = output.ToString(), Key = _key };
        }

        public string Decrypt(string data, int key)
        {
            var dict = CreateDictTable(key);
            var input = data.ToCharArray();
            var result = DecryptLoop(dict, input);

            var output = result.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next));

            return output.ToString();
        }

        private Dictionary<char, char> CreateDictTable(int key)
        {
            var dict = new Dictionary<char, char>();
            var ascii = GetAsciiTable();

            for (int i = 0; i < ascii.Count; i++)
            {
                dict.Add(ascii[i], GetCharInRange(ascii, i, key));
            }
            return dict;
        }

        private char GetCharInRange(List<char> table, int index, int key)
        {
            if (index + key < table.Count)
                return table[index + key];
            return table[(index + key) - table.Count];
        }
    }
}