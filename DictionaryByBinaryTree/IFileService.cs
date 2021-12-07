using System;
using System.Collections.Generic;

namespace DictionaryByBinaryTree
{
    public interface IFileService
    {
        void WriteToFile(string path, string content, bool isClose = true);
        string? ReadFromFile(string path, bool isClose = true );
    }
}