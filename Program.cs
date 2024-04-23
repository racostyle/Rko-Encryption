using ExtensionMethods;

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

            Console.WriteLine($"Input: {primer}");
            Console.WriteLine($"Hash1: {hash1}");
            Console.WriteLine($"Hash2: {hash2}");
            Console.WriteLine($"Hash3: {hash3}");
            Console.WriteLine($"Hash4: {hash4}");
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
