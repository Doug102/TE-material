using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        [TestMethod]
        public void IsLessThanMultipleOf2018()
        {
            Less20 test = new Less20();

            bool result = test.IsLessThanMultipleOf20(18);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void IsLessThanMultipleOf2019()
        {
            Less20 test = new Less20();

            bool result = test.IsLessThanMultipleOf20(19);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void IsLessThanMultipleOf2020()
        {
            Less20 test = new Less20();

            bool result = test.IsLessThanMultipleOf20(20);

            Assert.AreEqual(false, result);
        }


    }
}
