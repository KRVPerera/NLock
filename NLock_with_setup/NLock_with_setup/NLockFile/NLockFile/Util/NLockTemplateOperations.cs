using System;
using System.IO;
using NLock.NLockFile.Exceptions;

namespace NLock.NLockFile.Util
{
    public abstract class NLockTemplateOperations
    {
        #region Private Static

        private static int IsNLock(byte[] content)
        {
            var headeridN = new byte[] {0x4E, 0x4C, 0x4F, 0x43, 0x4B}; //NLOCK
            var headeridP = new byte[] {0x4E, 0x4C, 0x4F, 0x43, 0x50}; //NLOCP

            if (IsNLock(content, headeridN))
            {
                return 1;
            }
            if (IsNLock(content, headeridP))
            {
                return 2;
            }
            return -1;
        }

        private static byte[] ExtractContentFrom(string filePath, int start)
        {
            byte[] extractedContent;

            using (var fs = File.OpenRead(filePath))
            {
                var length = fs.Length - start;
                extractedContent = new byte[length];
                fs.Seek(start, SeekOrigin.Begin);
                fs.Read(extractedContent, 0, extractedContent.Length);

                fs.Close();
            }
            return extractedContent;
        }

        private static bool IsNLock(byte[] content, byte[] key)
        {
            for (var i = 0; i < 5; i++)
            {
                if (content[i] != key[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] ExtractContentFrom(byte[] full, int start)
        {
            var extractedContent = ExtractContentFromTo(full, start, full.Length);
            return extractedContent;
        }

        #endregion

        #region Public Static

        public static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length*sizeof (char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static int IsNLock(string filePath)
        {
            var isNlock = -1;
            using (var fs = File.OpenRead(filePath))
            {
                var b = new byte[5];

                fs.Read(b, 0, b.Length);

                isNlock = IsNLock(b);

                fs.Close();
            }

            return isNlock;
        }

        #endregion

        #region Protected Static

        protected static byte[] ExtractContentFromTo(byte[] full, int start, int end)
        {
            var length = end - start;
            var extractedContent = new byte[length];
            Buffer.BlockCopy(full, start, extractedContent, 0, length);
            return extractedContent;
        }

        protected static byte[] ExtractTemplateFromNLock(byte[] full, int headerLength)
        {
            try
            {
                if (IsNLock(full) > 0)
                {
                    var header = ExtractContentFromTo(full, 0, headerLength);
                    return ExtractContentFromTo(header, 5, headerLength);
                }
            }
            catch (Exception)
            {
                throw new NLockFileCorruptedException("Template extraction failed");
            }
            return null;
        }

        protected static byte[] ExtractDataContentFromNLock(string filePath, int headerLength)
        {
            if (IsNLock(filePath) > 0)
            {
                return ExtractContentFrom(filePath, headerLength);
            }
            return null;
        }

        protected static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length/sizeof (char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        protected static byte[] ExtractDataContentFromNLock(byte[] full, int headerLength)
        {
            if (IsNLock(full) > 0)
            {
                return ExtractContentFrom(full, headerLength);
            }
            return null;
        }

        #endregion

        #region Public Abstract

        public abstract int TemplateLength { get; }
        public abstract byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent);

        public abstract byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent,
            string password = "null");

        public abstract byte[] GetHashFromNLock(byte[] full);
        public abstract byte[] ExtractDataContentFromNLock(string filePath);
        public abstract byte[] ExtractTemplateFromNLock(byte[] full);
        public abstract byte[] ExtractDataContentFromNLock(byte[] full);

        #endregion
    }
}