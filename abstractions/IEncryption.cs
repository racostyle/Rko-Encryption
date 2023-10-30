namespace Rko_encription
{
    public interface IEncryption
    {
        SEncriptionResult Encrypt(string data);
        string Decrypt(string data, int key);
    }
}