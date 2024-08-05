namespace ChatConnectInterfaces.Access
{
    public interface IEncryptionService
    {
        public string Encrypt(string key);

        public string Decrypt(string key);
    }
}
