using System;

namespace NLock.NLockFile.Encryption
{
    internal interface IEncryptionStrategy
    {
        string Stratergy { get; set; }

        byte[] Encrypt(byte[] keyArray, byte[] content, byte[] key = null);

        byte[] Decrypt(byte[] keyArray, byte[] content, byte[] key = null);
    }
}