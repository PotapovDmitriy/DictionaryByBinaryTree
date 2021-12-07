using System;
using System.IO;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    public class FileService<TKey, TValue> where TKey : IComparable<TKey>
    {
        public void WriteDictionaryToFile(SelfMadeDictionary<TKey, TValue> dictionary,
            string path = "test.txt")
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(dictionary));
        }

        public SelfMadeDictionary<TKey, TValue> ReadDictionaryFromFile(string path = "test.txt")
        {
            var dictionaryString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<SelfMadeDictionary<TKey, TValue>>(dictionaryString);
        }
    }
}