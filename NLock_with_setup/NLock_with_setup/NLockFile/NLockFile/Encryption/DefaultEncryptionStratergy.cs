using System;

namespace NLock.NLockFile.Encryption
{
    /// <summary>
    ///  XOR Operation
    /// </summary>
    [Obsolete("use AESEncryptionStrategy instead")]
    internal class DefaultEncryptionStratergy : IEncryptionStrategy
    {
        public string Stratergy { get; set; }

        public byte[] Encrypt(byte[] keyArray, byte[] content, byte[] key = null)
        {
            var encryptedLength = 0;
            for (int i = 0; i < content.Length; i++)
            {
                content[i] = (byte)(content[i] ^ keyArray[encryptedLength]);

                encryptedLength += i;
                if (encryptedLength >= keyArray.Length - 1)
                {
                    encryptedLength = 0;
                }
            }
            return content;
        }

        public byte[] Decrypt(byte[] keyArray, byte[] content, byte[] key = null)
        {
            return Encrypt(keyArray, content);
        }
    }
}