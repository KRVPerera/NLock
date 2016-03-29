using System.IO;
using System.Security.Cryptography;

namespace NLock.NLockFile.Encryption
{
    /// <summary>
    ///     Ref : http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt
    ///     http://stackoverflow.com/questions/14368068/how-to-solve-system-outofmemoryexception-in-c
    ///
    ///     TODO : Use asynchronous operations here to handle large tasks
    /// </summary>
    internal class AESEncryptionStrategy : IEncryptionStrategy
    {
        public string Stratergy { get; set; }

        public byte[] Encrypt(byte[] keyArray, byte[] content, byte[] keyAdd = null)
        {
            byte[] encryptedBytes = null;
            var saltBytes = new byte[] { 2, 3, 9, 4, 2, 6, 2, 8 };
            using (MemoryStream inmem = new MemoryStream(content))
            using (MemoryStream ms = new MemoryStream())
            {
                inmem.Seek(0, SeekOrigin.Begin);
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.Padding = PaddingMode.PKCS7;
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    using (var key = new Rfc2898DeriveBytes(keyArray, saltBytes, 1000))
                    {
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        byte[] buffer = new byte[AES.BlockSize * 5];
                        int bufferLength;
                        long bytesProcessed = 0;
                        long inputFileLength = inmem.Length;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            while (bytesProcessed < inputFileLength)
                            {
                                bufferLength = inmem.Read(buffer, 0, buffer.Length);
                                cs.Write(buffer, 0, bufferLength);
                                bytesProcessed += bufferLength;
                            }
                            cs.FlushFinalBlock();
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }
            }

            return encryptedBytes;
        }

        public byte[] Decrypt(byte[] keyArray, byte[] content, byte[] keyAdd = null)
        {
            byte[] decryptedBytes = null;

            var saltBytes = new byte[] { 2, 3, 9, 4, 2, 6, 2, 8 };
            using (MemoryStream inmem = new MemoryStream(content))
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Padding = PaddingMode.PKCS7;

                    using (var key = new Rfc2898DeriveBytes(keyArray, saltBytes, 1000))
                    {
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        byte[] buffer = new byte[AES.BlockSize*3];
                        int bufferLength;
                        long bytesProcessed = 0;
                        long inputFileLength = inmem.Length;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            while (bytesProcessed < inputFileLength)
                            {
                                bufferLength = inmem.Read(buffer, 0, buffer.Length);
                                cs.Write(buffer, 0, bufferLength);
                                bytesProcessed += bufferLength;
                            }
                            cs.FlushFinalBlock();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }
            }

            return decryptedBytes;
        }
    }
}