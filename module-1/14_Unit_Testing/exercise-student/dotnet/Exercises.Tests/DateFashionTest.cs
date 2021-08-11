using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [TestMethod]
        public void GetATableMidHigh()
        {
            DateFashion test = new DateFashion();

            int result = test.GetATable(5, 10);

            Assert.AreEqual(2, result);

        }
        [TestMethod]
        public void GetATableMidLow()
        {
            DateFashion test = new DateFashion();

            int result = test.GetATable(5, 2);

            Assert.AreEqual(0, result);

        }
        [TestMethod]
        public void GetATableMidMid()
        {
            DateFashion test = new DateFashion();

            int result = test.GetATable(5, 5);

            Assert.AreEqual(1, result);

        }

    }
}
