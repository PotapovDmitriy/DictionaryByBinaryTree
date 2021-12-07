using System.Collections.Generic;
using System.IO;
using DictionaryByBinaryTree;
using NUnit.Framework;

namespace TestDictionary
{
    public class FileServiceTest
    {
        [Test]
        public void SaveDictionaryTest()
        {
            var testFilePath =
                "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test.txt";
            var actualFilePath =
                "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test1.txt";

            var fileService = new FileService();
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic.Add(1, "One");
            testedDic.Add(2, "Two");
            
            fileService.WriteDictionaryToFile(testedDic, actualFilePath);

            var expectedString = File.ReadAllText(testFilePath);
            var actualString = File.ReadAllText(actualFilePath);
            
            Assert.AreEqual(expectedString, actualString);
        }
        
        [Test]
        public void ReadDictionaryTest()
        {
            var testFilePath =
                "D:\\rider projects\\DictionaryByBinaryTree\\DictionaryByBinaryTree\\TestDictionary\\test.txt";
            

            var fileService = new FileService();
            var testedDic = fileService.ReadDictionaryFromFile<int, string>(testFilePath);
            var assertedDic = new Dictionary<int, string>
            {
                {1, "One"}, {2, "Two"}
            };
            
            Assert.AreEqual(assertedDic, testedDic);
        }
    }
}