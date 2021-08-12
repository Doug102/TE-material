using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Test
    {
        [TestMethod]
        public void MakeArrayFirst1Last3()
        {
            MaxEnd3 test = new MaxEnd3();

            int[] result = test.MakeArray(new int[] { 1, 2, 3 });

            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);
        }
        [TestMethod]
        public void MakeArrayFirst11Last9()
        {
            MaxEnd3 test = new MaxEnd3();

            int[] result = test.MakeArray(new int[] { 11, 5, 9 });

            CollectionAssert.AreEqual(new int[] { 11, 11, 11 }, result);
        }
        [TestMethod]
        public void MakeArrayFirst2Last3()
        {
            MaxEnd3 test = new MaxEnd3();

            int[] result = test.MakeArray(new int[] { 2, 11, 3 });

            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);
        }

    }
}
