using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DictionaryByBinaryTree;
using NUnit.Framework;

namespace TestDictionary
{
    
    public class MemoryStreamService : IFileService
    {
        public MemoryStream stream = new MemoryStream();

        public Stream GetReadStream(string name)
        {
            stream.Position = 0;
            return stream;
        }

        public Stream GetWriteStream(string name)
        {
            return stream;
        }
    }
    
    public class FileServiceTest
    {
        [Test]
        public void SaveDictionaryTest()
        {
            var serializer = new SerializeDictionary();
            var fileService = new MemoryStreamService();
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic.Add(1, "One");
            testedDic.Add(2, "Two");
            
            var assertedDic = new Dictionary<int, string>
            {
                {1, "One"}, {2, "Two"}
            };
            serializer.WriteDictionaryToFile(testedDic, fileService, closeStream: false);

            var newDic = serializer.ReadDictionaryFromFile<int, string>(fileService);

            Assert.AreEqual(0, assertedDic.Except(newDic).Count());
            
        }
    }
}