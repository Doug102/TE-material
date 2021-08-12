using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests

{
    [TestClass]
    public class StringBitsTest
    {
        [TestMethod]
        public void GetBitsHello()
        {
            StringBits test = new StringBits();

            string result = test.GetBits("Hello");

            Assert.AreEqual("Hlo", result);
        }
        [TestMethod]
        public void GetBitsHi()
        {
            StringBits test = new StringBits();

            string result = test.GetBits("Hi");

            Assert.AreEqual("H", result);
        }
        [TestMethod]
        public void GetBitsHeeololeo()
        {
            StringBits test = new StringBits();

            string result = test.GetBits("Heeololeo");

            Assert.AreEqual("Hello", result);
        }

    }
}
