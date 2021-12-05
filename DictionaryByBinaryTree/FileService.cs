using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    public class FileService<TKey, TValue> where TKey : IComparable<TKey>
    {
        public void WriteDictionaryToFileAsync(SelfMadeDictionary<TKey, TValue> dictionary,
            string path = "test.txt")
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(dictionary));
        }

        public SelfMadeDictionary<TKey, TValue> ReadDictionaryFromFileAsync(string path = "test.txt")
        {
            var dictionaryString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<SelfMadeDictionary<TKey, TValue>>(dictionaryString);
        }
    }
}