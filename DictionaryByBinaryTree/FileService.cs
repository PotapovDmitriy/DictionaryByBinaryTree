using System;
using System.IO;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    public class FileService 
    {
        public void WriteDictionaryToFile<TKey, TValue>(SelfMadeDictionary<TKey, TValue> dictionary,
            string path = "test.txt") where TKey : IComparable<TKey>
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(dictionary));
        }

        public SelfMadeDictionary<TKey, TValue> ReadDictionaryFromFile<TKey, TValue>(string path = "test.txt")
            where TKey : IComparable<TKey>
        {
            var dictionaryString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<SelfMadeDictionary<TKey, TValue>>(dictionaryString);
        }
    }
}