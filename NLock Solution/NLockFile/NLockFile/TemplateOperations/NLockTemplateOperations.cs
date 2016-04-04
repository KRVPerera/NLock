using NLock.NLockFile.Exceptions;
using System;
using System.IO;

namespace NLock
{
    public abstract class NLockTemplateOperations
    {
        public abstract int TemplateLength
        {
            get;
        }

        public abstract int HeaderLength
        {
            get;
        }

        public abstract byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent);

        public abstract byte[] GenerateNLockFileContent(byte[] template, byte[] originalFileContent, String password = "null");

        public abstract byte[] GetHashFromNLock(byte[] full);

        public static byte[] ExtractContentFromTo(byte[] full, int start, int end)
        {
            var length = end - start;
            var extractedContent = new byte[length];
            Buffer.BlockCopy(full, start, extractedContent, 0, length);
            return extractedContent;
        }

        public static byte[] ExtractContentFrom(string filePath, int start)
        {
            byte[] extractedContent;

            using (FileStream fs = File.OpenRead(filePath))
            {
                var length = fs.Length - start;
                extractedContent = new byte[length];
                fs.Seek(start, SeekOrigin.Begin);
                fs.Read(extractedContent, 0, extractedContent.Length);

                fs.Close();
            }
            return extractedContent;
        }

        public abstract byte[] ExtractTemplateFromNLock(byte[] full);

        public static byte[] ExtractTemplateFromNLock(byte[] full, int headerLength)
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

        public abstract byte[] ExtractDataContentFromNLock(string filePath);

        public static byte[] ExtractDataContentFromNLock(string filePath, int headerLength)
        {
            if (IsNLock(filePath) > 0)
            {
                return ExtractContentFrom(filePath, headerLength);
            }
            return null;
        }

        public static int IsNLock(byte[] content)
        {
            var headeridN = new byte[] { 0x4E, 0x4C, 0x4F, 0x43, 0x4B }; //NLOCK
            var headeridP = new byte[] { 0x4E, 0x4C, 0x4F, 0x43, 0x50 }; //NLOCP

            if (IsNLock(content, headeridN))
            {
                return 1;
            }
            else if (IsNLock(content, headeridP))
            {
                return 2;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsNLock(byte[] content, byte[] key)
        {
            for (int i = 0; i < 5; i++)
            {
                if (content[i] != (byte)key[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int IsNLock(string filePath)
        {
            var isNlock = -1;
            using (FileStream fs = File.OpenRead(filePath))
            {
                var b = new byte[5];

                fs.Read(b, 0, b.Length);

                isNlock = IsNLock(b);

                fs.Close();
            }

            return isNlock;
        }

        public static byte[] ExtractDataContentFromNLock(byte[] full, int headerLength)
        {
            if (IsNLock(full) > 0)
            {
                return ExtractContentFrom(full, headerLength);
            }
            return null;
        }

        public abstract byte[] ExtractDataContentFromNLock(byte[] full);

        public static byte[] ExtractContentFrom(byte[] full, int start)
        {
            var extractedContent = ExtractContentFromTo(full, start, full.Length);
            return extractedContent;
        }

        public static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}