using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [TestMethod]
        public void GetPartialStringHelloThere()
        {
            NonStart test = new NonStart();

            string result = test.GetPartialString("Hello", "There");

            Assert.AreEqual("ellohere", result);
        }
        [TestMethod]
        public void GetPartialStringJavaCode()
        {
            NonStart test = new NonStart();

            string result = test.GetPartialString("java", "code");

            Assert.AreEqual("avaode", result);
        }
        [TestMethod]
        public void GetPartialStringShotlJava()
        {
            NonStart test = new NonStart();

            string result = test.GetPartialString("shotl", "java");

            Assert.AreEqual("hotlava", result);
        }

    }
}
