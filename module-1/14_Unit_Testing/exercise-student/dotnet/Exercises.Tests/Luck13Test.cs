using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class Luck13Test
    {
        [TestMethod]
        public void GetLucky024()
        {
            Lucky13 test = new Lucky13();

            bool result = test.GetLucky(new int[] { 0, 2, 4 });

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void GetLucky123()
        {
            Lucky13 test = new Lucky13();

            bool result = test.GetLucky(new int[] { 1, 2, 3 });

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void GetLucky124()
        {
            Lucky13 test = new Lucky13();

            bool result = test.GetLucky(new int[] { 1, 2, 4 });

            Assert.AreEqual(false, result);
        }


    }
}
