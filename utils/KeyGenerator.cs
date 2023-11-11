namespace Rko_encription
{
    internal class KeyGenerator
    {
        private static Random r;
        static KeyGenerator()
        {
            r = new Random();
        }

        public static int GenerateKey()
        {
            var key = r.Next(1, Stafi.NO_OF_CHARACTERS / 2);
            Console.WriteLine($"Generated key: {key}");
            return key;
        }
    }
}
