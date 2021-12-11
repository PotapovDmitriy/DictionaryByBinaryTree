using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    public class SerializeDictionary
    {
        public void WriteDictionaryToFile<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            IFileService fileService, string path = "test.txt", bool closeStream = true) where TKey : IComparable<TKey>
        {
            
            var formatter = new DataContractJsonSerializer(typeof(IDictionary<TKey, TValue>));

            Stream fs = fileService.GetWriteStream(path);
            formatter.WriteObject(fs, dictionary);

            if (closeStream)
                fs.Close();

        }

        public IDictionary<TKey, TValue> ReadDictionaryFromFile<TKey, TValue>(IFileService fileService,
            string path = "test.txt",
            bool closeStream = true)
            where TKey : IComparable<TKey>
        {
            var formatter = new DataContractJsonSerializer(typeof(IDictionary<TKey, TValue>));
            var fs = fileService.GetReadStream(path);

            var result = (IDictionary<TKey, TValue>) formatter.ReadObject(fs);

            if (closeStream)
                fs.Close();

            return result;
        }
    }
}