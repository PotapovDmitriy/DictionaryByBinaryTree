using System;

namespace DictionaryByBinaryTree.Models
{
    /// <summary>
    /// Key should be IComparable
    /// </summary>
    /// <typeparam name="V">Value type</typeparam>
    public class DictionaryItem<K, V> : IComparable<DictionaryItem<K, V>> 
        where K: IComparable<K>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public int CompareTo(DictionaryItem<K, V> other)
        {
            return Key.CompareTo(other.Key);
        }
    }
}