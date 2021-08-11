using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        [TestMethod]
        public void HavePartyLowCigarWeekday()
        {
            CigarParty test = new CigarParty();

           bool result =  test.HaveParty(30, false);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void HavePartyEnoughCigarWeekday()
        {
            CigarParty test = new CigarParty();

            bool result = test.HaveParty(50, false);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void HavePartyHighCigarWeekend()
        {
            CigarParty test = new CigarParty();

            bool result = test.HaveParty(70, true);

            Assert.AreEqual(true, result);
        }


    }
}
