using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNamesTest
    {
        [TestMethod]
        public void GetHerdWithGiraffe()
        {
            AnimalGroupName exercise = new AnimalGroupName();

            string result = exercise.GetHerd("Giraffe");

            Assert.AreEqual("Tower", result);

        }

        [TestMethod]
        public void GetHerdWithEmptyString()
        {
            AnimalGroupName exercise = new AnimalGroupName();

            string result = exercise.GetHerd("");

            Assert.AreEqual("unknown", result);

        }

        [TestMethod]
        public void GetHerdWithRhino()
        {
            AnimalGroupName exercise = new AnimalGroupName();

            string result = exercise.GetHerd("Rhino");

            Assert.AreEqual("Crash", result);

        }



    }



}
