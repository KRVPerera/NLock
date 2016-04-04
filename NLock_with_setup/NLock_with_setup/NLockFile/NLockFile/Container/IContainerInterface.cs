using System;
using System.Collections.Generic;

namespace NLock.NLockFile.Container
{
    public interface IContainerInterface : IDisposable
    {
        bool AddFile(String filePath);

        bool RemoveFile(String filePath);

        byte[] GetContent();

        bool LoadFromMemory(byte[] content);

        bool ExtractToFolder(String folderPath);

        bool AddFolder(String folderPath, bool recursively = false, string folderName = null);

        List<NlFile> GetNlFileList();
    }
}