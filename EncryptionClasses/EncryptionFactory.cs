using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rko_encription
{
    internal enum EncryptionType { Classic, Double, DoubleWKey }

    internal class EncryptionFactory
    {
        internal IEncryption Create(EncryptionType type)
        {
            var key = KeyGenerator.GenerateKey();

            switch (type)
            {
                case EncryptionType.Double:
                    return new EncryptionDouble(
                        new EncryptionClassic(key));
                case EncryptionType.DoubleWKey:
                    return new EncryptionDoubleWKey(
                        new EncryptionDouble(
                            new EncryptionClassic(key)), 
                            new KeyEncryption(key));
                default: //EncryptionType.Classic
                    return new EncryptionClassic(key);
            }
        }
    }
}
