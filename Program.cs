using Rko_encription.Hash;

namespace Rko_encription
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var encrFactory = new EncryptionFactory();
            //var simpleEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.Classic));
            //var doubleEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.Double));
            //var doubleWkeyEncryption = new EncryptionProxy(encrFactory.Create(EncryptionType.DoubleWKey));

            //while (true)
            //{
            //    var text = SetText();

            //    Console.WriteLine(">>Classic");
            //    var result = simpleEncryption.Encrypt(text);
            //    simpleEncryption.Decrypt(result.Result, result.Key);

            //    Thread.Sleep(100);
            //    Console.WriteLine(">>Double");
            //    var result2 = doubleEncryption.Encrypt(text);
            //    doubleEncryption.Decrypt(result2.Result, result2.Key);

            //    Thread.Sleep(100);
            //    Console.WriteLine(">>Double W Key");
            //    var result3 = doubleWkeyEncryption.Encrypt(text);
            //    doubleWkeyEncryption.Decrypt(result3.Result, result3.Key);
            //}        

            HashPrimeri("Primer hasha za predmet VIZ");
            HashPrimeri("Primer hasha za predmet VIZ!");
            HashPrimeri("Primer hasha za predmet VIZ. Hash je lahko tudi zelo dolg in vpliva na rezultat ............. :)");
        }

        private static void HashPrimeri(string primer)
        {
            var hash1 = primer.ToHash(100);
            var hash2 = primer.ToHash(100);
            var hash3 = primer.ToHash(50);
            var hash4 = primer.ToHash(50);

            var hashSalt1 = primer.ToHashWithSalt(30);
            var hashSalt2 = primer.ToHashWithSalt(30, hashSalt1.Salt);

            Console.WriteLine($"Input: {primer}");
            Console.WriteLine($"Hash1 [100]: {hash1}");
            Console.WriteLine($"Hash2 [100]: {hash2}");
            Console.WriteLine($"Hash3  [50]: {hash3}");
            Console.WriteLine($"Hash4  [50]: {hash4}");
            Console.WriteLine("");
            Console.WriteLine($"HashSalt1 hash [30]: {hashSalt1.Hash}");
            Console.WriteLine($"HashSalt1 salt [30]: {hashSalt1.Salt}");
            Console.WriteLine($"HashSalt2 hash [30]: {hashSalt2.Hash}");
            Console.WriteLine($"HashSalt2 salt [30]: {hashSalt2.Salt}");
            Console.WriteLine("");
            
        }

        private static string SetText()
        {
            var text = Console.ReadLine();
            Console.WriteLine();
            return text;
        }
    }
}
