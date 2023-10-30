namespace Rko_encription
{
    public class EncryptionDecorator : IEncryption
    {
        private readonly IEncryption _encryption;

        public EncryptionDecorator(IEncryption encryption)
        {
            _encryption = encryption;
        }

        public SEncriptionResult Encrypt(string data)
        {
            var result = _encryption.Encrypt(data);
            var output = BeautifyResult(result.Result);
            Console.WriteLine($"Encrypted data: {output}");
            return result;
        }

        private string BeautifyResult(string result)
        {
            var r1 = result.Replace("\n", string.Empty);
            var r2 = result.Replace(" ", string.Empty);
            return r2.Trim();
        }

        public string Decrypt(string data, int key)
        {
            var result = _encryption.Decrypt(data, key);
            Console.WriteLine($"Restored text: {result}" + Environment.NewLine);
            return result;
        }
    }
}