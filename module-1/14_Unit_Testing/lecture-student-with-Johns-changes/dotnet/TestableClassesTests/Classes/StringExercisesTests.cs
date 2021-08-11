using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass]
    public class StringExercisesTests
    {
        [TestMethod]
        public void MakeAbbaReturnsSimpleString()
        {
            // Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.MakeAbba("Hi", "Bye");

            //Assert
            Assert.AreEqual("HiByeByeHi", result,"Please check your calculation and try again");
        }

        [TestMethod]
        public void FirstTwoWithASimpleString()
        {
            // Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("Hello");

            //Assert
            Assert.AreEqual("He", result, "Please check your calculation and try again");
        }

        [TestMethod]
        public void FirstTwoWithAStringOfLengthOne()
        {
            // Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("H");

            //Assert
            Assert.AreEqual("H", result, "Please check your calculation and try again");
        }

        [TestMethod]
        public void FirstTwoWithAStringOfLengthZero()
        {
            // Arrange
            StringExercises exercises = new StringExercises();

            //Act
            string result = exercises.FirstTwo("");

            //Assert
            Assert.AreEqual("", result, "Please check your calculation and try again");
        }









        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()



    }
}