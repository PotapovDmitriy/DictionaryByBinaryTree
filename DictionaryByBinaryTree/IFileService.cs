using System;
using System.Collections.Generic;
using System.IO;

namespace DictionaryByBinaryTree
{
    public interface IFileService
    {
        Stream GetReadStream(string name);
        Stream GetWriteStream(string name);
    }
}