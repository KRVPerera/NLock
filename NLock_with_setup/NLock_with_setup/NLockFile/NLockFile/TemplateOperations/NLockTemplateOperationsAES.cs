using System;

namespace NLock
{
    public class NLockTemplateOperationsAES : NLockTemplateOperations
    {
        #region Private variables

        private const int HEADERLENGTH = 4053;
        private const int TEMPLATELENGTH = 4048;
        private readonly byte[] headeridN = new byte[] { 0x4E, 0x4C, 0x4F, 0x43, 0x4B };

        #endregion Private variables


        #region Methods

        #region Public overrides

        public override int TemplateLength
        {
            get
            {
                return TEMPLATELENGTH;
            }
        }

        public override int HeaderLength
        {
            get
            {
                return HEADERLENGTH;
            }
        }

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent)
        {
            var header = CreateHeader(template, headeridN);

            var NLockFileContent = new byte[header.Length + originalFileContent.Length];

            Buffer.BlockCopy(header, 0, NLockFileContent, 0, header.Length);

            Buffer.BlockCopy(originalFileContent, 0, NLockFileContent, header.Length, originalFileContent.Length);

            return NLockFileContent;
        }

        public override byte[] ExtractTemplateFromNLock(byte[] full)
        {
            return ExtractTemplateFromNLock(full, HEADERLENGTH);
        }

        public override byte[] ExtractDataContentFromNLock(string filePath)
        {
            return ExtractDataContentFromNLock(filePath, HEADERLENGTH);
        }

        public override byte[] ExtractDataContentFromNLock(byte[] full)
        {
            return ExtractDataContentFromNLock(full, HEADERLENGTH);
        }

        public override byte[] GetHashFromNLock(byte[] full)
        {
            throw new NotImplementedException();
        }

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent, string password = "null")
        {
            throw new NotImplementedException();
        }

        #endregion Public overrides

        #region Private

        private static byte[] CreateHeader(byte[] template, byte[] headerid)
        {
            var header = new byte[headerid.Length + template.Length];
            Buffer.BlockCopy(headerid, 0, header, 0, headerid.Length);
            Buffer.BlockCopy(template, 0, header, headerid.Length, template.Length);

            return header;
        }

        #endregion Private

        #endregion Methods
    }
}