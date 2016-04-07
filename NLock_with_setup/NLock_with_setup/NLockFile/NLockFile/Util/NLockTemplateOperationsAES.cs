using System;

namespace NLock.NLockFile.Util
{
    public class NLockTemplateOperationsAes : NLockTemplateOperations
    {
        #region Private variables

        private const int Headerlength = 4053;
        private const int Templatelength = 4048;
        private readonly byte[] _headeridN = { 0x4E, 0x4C, 0x4F, 0x43, 0x4B };

        #endregion Private variables

        #region Methods

        #region Public overrides

        public override int TemplateLength
        {
            get { return Templatelength; }
        }

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent)
        {
            var header = CreateHeader(template, _headeridN);

            var nLockFileContent = new byte[header.Length + originalFileContent.Length];

            Buffer.BlockCopy(header, 0, nLockFileContent, 0, header.Length);

            Buffer.BlockCopy(originalFileContent, 0, nLockFileContent, header.Length, originalFileContent.Length);

            return nLockFileContent;
        }

        public override byte[] ExtractTemplateFromNLock(byte[] full)
        {
            try
            {
                return ExtractTemplateFromNLock(full, Headerlength);
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

        public override byte[] GetHashFromNLock(byte[] full)
        {
            throw new NotImplementedException();
        }

        public override byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent,
            string password = "null")
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