using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rko_encription
{
    internal class EncryptionDoubleWKey : AEncryption, IEncryption
    {
        private readonly EncryptionDouble _double;
        string _encryptedKey;
        int _decryptedKey;

        public EncryptionDoubleWKey(EncryptionDouble endDouble, KeyEncryption keyGenerator)
        {
            _double = endDouble;
            int key = keyGenerator.Key;
            _encryptedKey = keyGenerator.EncryptKey(key);
            _decryptedKey = keyGenerator.DecryptKey(_encryptedKey);
        }

        public string Decrypt(string data, int key)
        {
            return _double.Decrypt(data, key);
        }

        public SEncriptionResult Encrypt(string data)
        {
            Console.WriteLine($"Encrypted Key: {_encryptedKey}");
            Console.WriteLine($"Decrypted Key: {_decryptedKey}");
            Console.WriteLine();

            return _double.Encrypt(data);
        }
    }
}
