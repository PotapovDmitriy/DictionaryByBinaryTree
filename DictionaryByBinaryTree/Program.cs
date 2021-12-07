using System;
using System.Collections.Generic;
using BinaryTree;
using DictionaryByBinaryTree.Models;
using Newtonsoft.Json;

namespace DictionaryByBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<DictionaryItem<int, string>>();
            
            tree.Add(new DictionaryItem<int, string>
            {
                Key = 15, Value = "asd"
            });
            
            
            tree.Add(new DictionaryItem<int, string>
            {
                Key = 143, Value = "asd"
            });
            
            
            tree.Add(new DictionaryItem<int, string>
            {
                Key = 10, Value = "asd"
            });

            Console.WriteLine(tree.ToString());

            var selfMadeDic = new SelfMadeDictionary<int, string>();

            selfMadeDic[1] = "sdasd";
            selfMadeDic[2] = "sda";
            selfMadeDic[1] = "qwerqwr";
            selfMadeDic.Add(1, "asd");

            var fileService = new FileService();

            fileService.WriteDictionaryToFile(selfMadeDic);

            var newDic = fileService.ReadDictionaryFromFile<int, string>();
        }
    }
}