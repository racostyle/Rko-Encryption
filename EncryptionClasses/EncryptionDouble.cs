using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rko_encription
{
    internal class EncryptionDouble : AEncryption, IEncryption
    {
        private readonly EncryptionClassic _classic;
        private readonly Dictionary<char, char> _table;

        public EncryptionDouble(EncryptionClassic classic)
        {
            _classic = classic;
            //_table = GetAllLettersDict();
            _table = GetAllAsciiTableDict();
        }

        public string Decrypt(string data, int key)
        {
            var decrypt1 = _classic.Decrypt(data, key).ToCharArray();
            var output = DecryptLoop(_table, decrypt1);
            return output.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next)).ToString();
        }

        public SEncriptionResult Encrypt(string data)
        {
            var input = data.ToCharArray();
            var result = EncryptLoop(_table, input);

            var output = result.Aggregate(new StringBuilder(), (sb, next) => sb.Append(next));

            return _classic.Encrypt(output.ToString());
        }

        private Dictionary<char, char> GetAllAsciiTableDict()
        {
            var asciiTable = GetAsciiTable();
            var keys2 = asciiTable.Select(x => x).ToArray();
            var keys1 = asciiTable.SkipWhile((x, index) => index < asciiTable.Count() / 2).Reverse().ToArray();
            var scrambled = keys1.Union(keys2).ToArray();

            return asciiTable.Zip(scrambled, (k, v) => new { Key = k, Value = v })
                                   .ToDictionary(x => x.Key, x => x.Value);
        }

        private Dictionary<char, char> GetAllLettersDict()
        {
            //var keys = GetAsciiTable().SkipWhile(x => !x.Equals('A')).TakeWhile(x => !x.Equals('z')).ToList();
            var asciiTable = GetAsciiTable();
            var keys1 = asciiTable
                .SkipWhile(x => !x.Equals('A'))
                .TakeWhile(x => char.IsLetter(x))
                .ToList();
            var keys2 = asciiTable
                .SkipWhile(x => !x.Equals('a'))
                .TakeWhile(x => char.IsLetter(x))
                .ToList();
            var keys = keys1.Union(keys2).ToList();

            var values = keys.Select(x => x).Reverse().ToList();

            return keys.Zip(values, (k, v) => new { Key = k, Value = v })
                                   .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
