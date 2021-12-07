using System;
using System.Collections.Generic;
using System.Linq;
using DictionaryByBinaryTree;
using NUnit.Framework;

namespace TestDictionary
{
    public class Tests
    {
        private IDictionary<int, string> _assertedDic;

        [SetUp]
        public void Setup()
        {
            _assertedDic = new Dictionary<int, string>
            {
                {1, "One"}, {2, "Two"}
            };
        }

        [Test]
        public void MethodAddItemTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic.Add(1, "One");
            testedDic.Add(2, "Two");
            Assert.AreEqual(2, testedDic.Count);
            Assert.AreEqual(0, _assertedDic.Except(testedDic).Count());
        }

        [Test]
        public void AddItemByKeyTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();

            testedDic[1] = "One";
            testedDic[2] = "Two";

            Assert.AreEqual(2, testedDic.Count);
            Assert.AreEqual(0, _assertedDic.Except(testedDic).Count());
        }

        [Test]
        public void DeleteItemByKeyTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();

            testedDic[1] = "One";
            testedDic[2] = "Two";
            testedDic[3] = "Three";

            testedDic.Remove(3);

            Assert.AreEqual(2, testedDic.Count);
            Assert.AreEqual(0, _assertedDic.Except(testedDic).Count());
        }

        [Test]
        public void ClearTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();

            testedDic[1] = "One";
            testedDic[2] = "Two";
            testedDic[3] = "Three";

            Assert.AreEqual(3, testedDic.Count);

            testedDic.Clear();

            Assert.AreEqual(0, testedDic.Count);
        }

        [Test]
        public void GetKeysTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();

            testedDic[1] = "One";
            testedDic[2] = "Two";

            var keys = testedDic.Keys;

            Assert.AreEqual(_assertedDic.Keys, keys);
        }

        [Test]
        public void GetValuesTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic[1] = "One";
            testedDic[2] = "Two";

            var values = testedDic.Values;

            Assert.AreEqual(_assertedDic.Values, values);
        }

        [Test]
        public void ContainKeyTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic[1] = "One";
            testedDic[2] = "Two";


            Assert.AreEqual(true, testedDic.ContainsKey(1));
        }

        [Test]
        public void ContainsTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic[1] = "One";
            testedDic[2] = "Two";

            Assert.AreEqual(true, testedDic.Contains(new KeyValuePair<int, string>(1, "One")));
        }
        
        [Test]
        public void TryGetValueTest()
        {
            var testedDic = new SelfMadeDictionary<int, string>();
            testedDic[1] = "One";
            testedDic[2] = "Two";
            string value = ""; 
            Assert.AreEqual(true, testedDic.TryGetValue(1, out value ));
            Assert.AreEqual("One", value);
        }
    }
}