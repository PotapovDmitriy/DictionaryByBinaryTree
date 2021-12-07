using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    public class SerializeDictionary
    {
        public void WriteDictionaryToFile<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            IFileService fileService, string path = "test.txt", bool closeStream = true) where TKey : IComparable<TKey>
        {
            fileService.WriteToFile(path, JsonConvert.SerializeObject(dictionary), closeStream);
        }

        public IDictionary<TKey, TValue> ReadDictionaryFromFile<TKey, TValue>(IFileService fileService,
            string path = "test.txt",
            bool closeStream = true)
            where TKey : IComparable<TKey>
        {
            var dictionaryString = fileService.ReadFromFile(path, closeStream);

            return JsonConvert.DeserializeObject<SelfMadeDictionary<TKey, TValue>>(dictionaryString);
        }
    }
}