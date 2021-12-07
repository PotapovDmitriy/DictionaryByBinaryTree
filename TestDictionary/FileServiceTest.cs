using System.Collections.Generic;
using System.IO;
using System.Text;
using DictionaryByBinaryTree;
using NUnit.Framework;

namespace TestDictionary
{
    public class FileServiceMock : IFileService
    {
        private MemoryStream stringAsStream;

        public FileServiceMock()
        {
            this.stringAsStream = new MemoryStream();
        }

        public void WriteToFile(string path, string content, bool isClose)
        {
            StreamWriter sWriter = new StreamWriter(stringAsStream, Encoding.Unicode);
            sWriter.Write(content);
            stringAsStream.Position = 0L;

            if (isClose)
            {
                sWriter.Close();
                stringAsStream.Close();
            }
        }

        public string? ReadFromFile(string path, bool isClose)
        {
            using StreamReader sReader = new StreamReader(stringAsStream, Encoding.Unicode);
            return sReader.ReadLine();
        }
    }

    public class FileServiceTest
    {
        [Test]
        public void SaveDictionaryTest()
        {
            var testFilePath =
                "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test.txt";
            var actualFilePath =
                "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test1.txt";

            var serializer = new SerializeDictionary();
            var fileService = new FileServiceMock();
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic.Add(1, "One");
            testedDic.Add(2, "Two");
            
            
            serializer.WriteDictionaryToFile(testedDic, fileService, closeStream: false);

            var newDic = serializer.ReadDictionaryFromFile<int, string>(fileService);

            // var expectedString = File.ReadAllText(testFilePath);
            // var actualString = File.ReadAllText(actualFilePath);
            //
            // Assert.AreEqual(expectedString, actualString);
        }
        
        // [Test]
        // public void ReadDictionaryTest()
        // {
        //     var testFilePath =
        //         "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test.txt";
        //     
        //
        //     var fileService = new SerializeDictionary();
        //     var testedDic = fileService.ReadDictionaryFromFile<int, string>(testFilePath);
        //     var assertedDic = new Dictionary<int, string>
        //     {
        //         {1, "One"}, {2, "Two"}
        //     };
        //     
        //     Assert.AreEqual(assertedDic, testedDic);
        // }
    }
}