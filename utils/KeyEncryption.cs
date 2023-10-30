using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rko_encription
{
    internal class KeyEncryption : AEncryption
    {
        //private Dictionary<char, char> _table;
        private char[] _values;
        private Random r;
        public int Key { get; private set; }

        public KeyEncryption(int key) : this()
        {
            Key = key;
        }

        public KeyEncryption()
        {
            r = new Random();
            //_table = GetIntTable();
            _values = GetAsciiTable()
                .Where(x => !char.IsNumber(x))
                .ToArray();
        }

        internal int DecryptKey(string key)
        {
            var constDict = GenerateFixedDict();
            int decriptKey = DecryptSingle(constDict, key.First());
            int keyLength = DecryptSingle(constDict, key.Skip(1).Take(1).ToArray()[0]);
            var encKey = key.Reverse().Take(keyLength).ToArray();

            var numbDict = GenerateDict(decriptKey);
            var decript = DecryptLoop(numbDict, encKey);

            string numberString = new string(decript);
            int number = int.Parse(numberString);
            return number;
        }

        internal string EncryptKey(int key)
        {
            //generate encryption int
            int dictKey = r.Next(0, _values.Length - 11);
            //generate table acording to int
            var numbDict = GenerateDict(dictKey);
            var elseDict = GenerateRestDict(numbDict);
            var constDict = GenerateFixedDict();
            //encrypt keys
            var encryptedKey = EncryptLoop(numbDict, key.ToString().ToCharArray());
            var decriptKey = EncryptSingle(constDict, dictKey);
            var keyLength = EncryptSingle(constDict, key.ToString().Length);

            var sb = new StringBuilder();
            sb.Append(decriptKey);
            sb.Append(keyLength);

            for (int i = 0; i < 6; i++)
                sb.Append(elseDict.ElementAt(r.Next(0, elseDict.Count() - 1)));
            foreach (var item in encryptedKey)
                sb.Append(item);
            return sb.ToString();
        }

        #region Dict Generation
        private Dictionary<char, char> GenerateFixedDict()
        {
            var dict = new Dictionary<char, char>();
            int[] numbers = Enumerable.Range(0, _values.Count()).ToArray();

            for (int i = 0; i < _values.Count() - 1; i++)
                dict.Add((char)numbers[i], _values[i]);
            return dict;
        }

        private Dictionary<char, char> GenerateDict(int dictKey)
        {
            var dict = new Dictionary<char, char>();
            char[] numbers = Enumerable.Range(0, 10).Select(n => (char)('0' + n)).ToArray();

            for (int i = 0; i < _values.Count(); i++)
            {
                if (i < numbers.Count())
                    dict.Add(numbers[i], _values[dictKey + i]);
                else
                    break;
            }
            return dict;
        }
        private char[] GenerateRestDict(Dictionary<char, char> numbDict)
        {
            var st1 = _values.Reverse()
                .TakeWhile((x, index) => index < _values.Length / 2)
                .Union(_values).ToArray();

            return st1.Except(numbDict.Values).ToArray();
        }
        #endregion

        #region Extra Encrypt / decrypt
        private char DecryptSingle(Dictionary<char, char> dict, char item)
        {
            foreach (var d in dict)
            {
                if (item.Equals(d.Value))
                    return d.Key;
            }
            return '0';
        }
        private char EncryptSingle(Dictionary<char, char> dict, int item)
        {
            foreach (var d in dict)
            {
                if (item.Equals(d.Key))
                    return d.Value;
            }
            return '0';
        }
        #endregion
    }
}
