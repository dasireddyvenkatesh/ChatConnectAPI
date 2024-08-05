using ChatConnectInterfaces.Access;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace ChatConnectServices.Access
{
    public class EncryptionService : IEncryptionService
    {

        public string Encrypt(string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("16ByteSecretKey!");
                aesAlg.IV = Encoding.UTF8.GetBytes("1234567890123456");

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (MemoryStream msCompressed = new MemoryStream())
                            {
                                using (BrotliStream brotli = new BrotliStream(msCompressed, CompressionLevel.SmallestSize))
                                {
                                    byte[] plainBytes = Encoding.UTF8.GetBytes(key);
                                    brotli.Write(plainBytes, 0, plainBytes.Length);
                                    brotli.Flush();
                                }

                                byte[] compressedBytes = msCompressed.ToArray();
                                csEncrypt.Write(compressedBytes, 0, compressedBytes.Length);
                                csEncrypt.FlushFinalBlock();

                                return Convert.ToBase64String(msEncrypt.ToArray());
                            }
                        }
                    }
                }
            }
        }

        public string Decrypt(string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(key);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("16ByteSecretKey!");
                aesAlg.IV = Encoding.UTF8.GetBytes("1234567890123456");

                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                        {
                            csDecrypt.Write(cipherBytes, 0, cipherBytes.Length);
                            csDecrypt.FlushFinalBlock();

                            msDecrypt.Position = 0;

                            using (MemoryStream msDecompressed = new MemoryStream())
                            {
                                using (BrotliStream brotli = new BrotliStream(msDecrypt, CompressionMode.Decompress))
                                {
                                    brotli.CopyTo(msDecompressed);
                                }

                                byte[] decompressedBytes = msDecompressed.ToArray();
                                return Encoding.UTF8.GetString(decompressedBytes);
                            }
                        }
                    }
                }
            }
        }


    }
}
