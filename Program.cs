using System.Dynamic;

namespace Rko_encription
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encrFactory = new EncryptionFactory();
            var simpleEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.Classic));
            var doubleEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.Double));
            var doubleWkeyEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.DoubleWKey));

            while (true)
            {
                var text = SetText();

                Console.WriteLine(">>Classic");
                var result = simpleEncryption.Encrypt(text);
                simpleEncryption.Decrypt(result.Result, result.Key);

                Thread.Sleep(100);
                Console.WriteLine(">>Double");
                var result2 = doubleEncryption.Encrypt(text);
                doubleEncryption.Decrypt(result2.Result, result2.Key);

                Thread.Sleep(100);
                Console.WriteLine(">>Double W Key");
                var result3 = doubleWkeyEncryption.Encrypt(text);
                doubleWkeyEncryption.Decrypt(result3.Result, result3.Key);
            }        
        }

        private static string SetText()
        {
            var text = Console.ReadLine();
            Console.WriteLine();
            return text;
        }
    }
}
