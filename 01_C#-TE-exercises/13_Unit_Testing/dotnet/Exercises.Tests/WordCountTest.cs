using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTest
    {
        [TestMethod]
        public void GetCountBaBaBlackSheep()
        {
            WordCount test = new WordCount();

            Dictionary<string, int> result = test.GetCount(new string[] { "ba", "ba", "black", "sheep" });

            CollectionAssert.AreEqual(new Dictionary<string, int> { ["ba"] = 2, ["black"] = 1, ["sheep"] = 1 }, result);

        }
        [TestMethod]
        public void GetCountABACB()
        {
            WordCount test = new WordCount();

            Dictionary<string, int> result = test.GetCount(new string[] { "a", "b", "a", "c", "b" });

            CollectionAssert.AreEqual(new Dictionary<string, int> { ["a"] = 2, ["b"] = 2, ["c"] = 1 }, result);

        }
        [TestMethod]
        public void GetCountEmptyArray()
        {
            WordCount test = new WordCount();

            Dictionary<string, int> result = test.GetCount(new string[0]);

            CollectionAssert.AreEqual(new Dictionary<string, int> {}, result);

        }
        [TestMethod]
        public void GetCountCBA()
        {
            WordCount test = new WordCount();

            Dictionary<string, int> result = test.GetCount(new string[] { "c", "b", "a" });

            CollectionAssert.AreEqual(new Dictionary<string, int> { ["c"] = 1, ["b"] = 1, ["a"] = 1 }, result);

        }
    }
}
