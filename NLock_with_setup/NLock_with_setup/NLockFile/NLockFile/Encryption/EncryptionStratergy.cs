
namespace NLock.NLockFile.Encryption
{
    internal interface IEncryptionStrategy
    {
        byte[] Encrypt(byte[] keyArray, byte[] content, byte[] key = null);

        byte[] Decrypt(byte[] keyArray, byte[] content, byte[] key = null);
    }
}