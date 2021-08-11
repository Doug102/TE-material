using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {
        [TestMethod]
        public void IsItTheSame123()
        {
            SameFirstLast test = new SameFirstLast();

            bool result = test.IsItTheSame(new int[] {1, 2, 3});

            Assert.AreEqual(false, result); 

        }
        [TestMethod]
        public void IsItTheSame1231()
        {
            SameFirstLast test = new SameFirstLast();

            bool result = test.IsItTheSame(new int[] { 1, 2, 3, 1 });

            Assert.AreEqual(true, result);

        }
        [TestMethod]
        public void IsItTheSame121()
        {
            SameFirstLast test = new SameFirstLast();

            bool result = test.IsItTheSame(new int[] { 1, 2, 1});

            Assert.AreEqual(true, result);

        }




    }
}
