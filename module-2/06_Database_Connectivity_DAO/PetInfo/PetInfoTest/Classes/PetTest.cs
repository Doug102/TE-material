using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;

namespace PetInfoTest
{
    [TestClass]
    public class PetTest
    {
        Pet pet;

        [TestInitialize]
        public void Setup()
        {
           pet = new Pet(999, "Bobo", "snake", "Blacksnake");
        }

        [TestCleanup]
        public void Cleanup()
        {
            //no cleanup needed - you could leave this method out
        }

        [TestMethod]
        public void PetConstructor()
        {
            Assert.IsNotNull(pet);
        }

        [TestMethod]
        public void PetProperties()
        {
            Assert.AreEqual(999, pet.Id, "Id failed");
            Assert.AreEqual("Bobo", pet.Name, "Name failed");
            Assert.AreEqual("snake", pet.Type, "Type failed");
            Assert.AreEqual("Blacksnake", pet.Breed, "Breed failed");
        }
    }
}
