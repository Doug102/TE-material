using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [TestMethod]
        public void GenerateStringChocolateTwo()
        {
            FrontTimes test = new FrontTimes();

            string result = test.GenerateString("Chocolate", 2);

            Assert.AreEqual("ChoCho", result);

        }
        [TestMethod]
        public void GenerateStringChocolateThree()
        {
            FrontTimes test = new FrontTimes();

            string result = test.GenerateString("Chocolate", 3);

            Assert.AreEqual("ChoChoCho", result);

        }
        [TestMethod]
        public void GenerateStringAbcThree()
        {
            FrontTimes test = new FrontTimes();

            string result = test.GenerateString("Abc", 3);

            Assert.AreEqual("AbcAbcAbc", result);

        }


    }
}
