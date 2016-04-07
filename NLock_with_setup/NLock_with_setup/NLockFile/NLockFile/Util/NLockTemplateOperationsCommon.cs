using System;
using System.Security.Cryptography;

namespace NLock.NLockFile.Util
{
    public class NLockTemplateOperationsCommon : NLockTemplateOperations
    {
        #region Public properties

        public override int TemplateLength
        {
            get { return Templatestize; }
        }

        #endregion Public properties

        #region Private variables

        private const int SaltByteSize = 257;
        private const int HashByteSize = 257;
        private const int Pbkdf2Iterations = 1000;
        private const int Passwordlength = SaltByteSize + HashByteSize; // 257+257 = 541
        private const int Templatestize = 4048;
        private const int Nlock = 5;
        private const int Headerlength = Templatestize + Nlock + Passwordlength; // 4048+5+541 = 4594
        private const int Templateend = Templatestize + Nlock; // 4053

        #endregion Private variables

        #region Methods

        #region Public overrides

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent)
        {
            return GenerateNLockFileContent(template, originalFileContent);
        }

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent,
            string password = "null")
        {
            // Create header
            var header = CreateHeader(template, password);

            var nLockFileContent = new byte[header.Length + originalFileContent.Length];

            Buffer.BlockCopy(header, 0, nLockFileContent, 0, header.Length);

            Buffer.BlockCopy(originalFileContent, 0, nLockFileContent, header.Length, originalFileContent.Length);

            return nLockFileContent;
        }

        public override byte[] GetHashFromNLock(byte[] full)
        {
            return ExtractContentFromTo(full, Templateend, Headerlength);
        }

        public override byte[] ExtractTemplateFromNLock(byte[] full)
        {
            try
            {
                return ExtractTemplateFromNLock(full, Templateend);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override byte[] ExtractDataContentFromNLock(string filePath)
        {
            return ExtractDataContentFromNLock(filePath, Headerlength);
        }

        public override byte[] ExtractDataContentFromNLock(byte[] full)
        {
            return ExtractDataContentFromNLock(full, Headerlength);
        }

        #endregion Public overrides

        #region public

        public static bool ValidatePassword(byte[] password, byte[] correcthashed)
        {
            var salt = new byte[SaltByteSize];
            var hash = new byte[HashByteSize];
            Buffer.BlockCopy(correcthashed, 0, salt, 0, SaltByteSize);
            Buffer.BlockCopy(correcthashed, SaltByteSize, hash, 0, HashByteSize);
            var pw = GetString(password);
            var testHash = PBKDF2(pw, salt, Pbkdf2Iterations, HashByteSize);
            return SlowEquals(hash, testHash);
        }

        #endregion public

        #region private

        private static byte[] CreateHeader(byte[] template, string password)
        {
            var headerid = new byte[] { 0x4E, 0x4C, 0x4F, 0x43, 0x50 }; //NLOCK
            var hashed = CreateHashByte(password);
            var header = new byte[headerid.Length + template.Length + hashed.Length];
            Buffer.BlockCopy(headerid, 0, header, 0, headerid.Length);
            Buffer.BlockCopy(template, 0, header, headerid.Length, template.Length);
            Buffer.BlockCopy(hashed, 0, header, headerid.Length + template.Length, hashed.Length);
            return header;
        }

        private static byte[] CreateHashByte(string password)
        {
            // Generate a random salt
            using (var csprng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltByteSize];
                csprng.GetBytes(salt);

                // Hash the password and encode the parameters
                var hash = PBKDF2(password, salt, Pbkdf2Iterations, HashByteSize);
                var ret = new byte[SaltByteSize + HashByteSize];
                Buffer.BlockCopy(salt, 0, ret, 0, SaltByteSize);
                Buffer.BlockCopy(hash, 0, ret, SaltByteSize, HashByteSize);
                return ret;
            }
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt)
            {
                IterationCount = iterations
            })
            {
                return pbkdf2.GetBytes(outputBytes);
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint) a.Length ^ (uint) b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint) (a[i] ^ b[i]);
            return diff == 0;
        }

        #endregion private

        #endregion Methods
    }
}