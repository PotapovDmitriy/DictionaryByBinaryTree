using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BinaryTree;
using DictionaryByBinaryTree.Models;

namespace DictionaryByBinaryTree
{
    public class SelfMadeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public SelfMadeDictionary()
        {
            Tree = new BinaryTree<DictionaryItem<TKey, TValue>>();
        }

        private BinaryTree<DictionaryItem<TKey, TValue>> Tree { get; }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            using var treeEnumerator = Tree.GetEnumerator();
            var result = new List<KeyValuePair<TKey, TValue>>();
            while (treeEnumerator.MoveNext())
            {
                if (treeEnumerator.Current is null)
                    continue;

                var item = new KeyValuePair<TKey, TValue>(treeEnumerator.Current.Key, treeEnumerator.Current.Value);
                result.Add(item);
            }

            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            var dictionaryItem = Tree.FirstOrDefault(i => i.Key.CompareTo(item.Key) == 0);
            if (dictionaryItem is not null)
                dictionaryItem.Value = item.Value;
            else
                Tree.Add(new DictionaryItem<TKey, TValue>()
                {
                    Key = item.Key, Value = item.Value
                });
        }

        public void Clear()
        {
            Tree.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Tree.Contains(ConvertToDictionaryItem(item));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                array[counter] = enumerator.Current;
                counter++;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Tree.Remove(ConvertToDictionaryItem(item));
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            return Tree.Contains(new DictionaryItem<TKey, TValue>
            {
                Key = key
            });
        }

        public bool Remove(TKey key)
        {
            var item = Tree.FirstOrDefault(i => i.Key.CompareTo(key) == 0);

            return Tree.Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var item = Tree.FirstOrDefault(i => i.Key.CompareTo(key) == 0);

            value = item is not null ? item.Value : default!;

            return item != null;
        }

        private DictionaryItem<TKey, TValue> ConvertToDictionaryItem(KeyValuePair<TKey, TValue> item)
        {
            return new DictionaryItem<TKey, TValue>
            {
                Key = item.Key,
                Value = item.Value
            };
        }

        public TValue this[TKey key]
        {
            get
            {
                var item = Tree.FirstOrDefault(i => i.Key.CompareTo(key) == 0);
                return item is null
                    ? throw new KeyNotFoundException($"Key {key} not found!!!")
                    : item.Value;
            }
            set
            {
                var item = Tree.FirstOrDefault(i => i.Key.CompareTo(key) == 0);
                if (item is not null)
                    item.Value = value;
                else
                    Tree.Add(new DictionaryItem<TKey, TValue>()
                    {
                        Key = key, Value = value
                    });
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                using var enumerator = GetEnumerator();
                var result = new Collection<TKey>();
                while (enumerator.MoveNext())
                {
                    result.Add(enumerator.Current.Key);
                }

                return result;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                using var enumerator = GetEnumerator();
                var result = new Collection<TValue>();
                while (enumerator.MoveNext())
                {
                    result.Add(enumerator.Current.Value);
                }

                return result;
            }
        }

        public int Count
        {
            get => Tree.Count;
        }

        public bool IsReadOnly
        {
            get => Tree.IsReadOnly;
        }
    }
}