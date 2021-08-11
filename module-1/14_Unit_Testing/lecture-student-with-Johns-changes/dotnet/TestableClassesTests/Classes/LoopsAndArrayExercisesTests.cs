using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class LoopsAndArrayExercisesTests
    {
        [TestMethod]
        public void MiddleWayWithSimpleArray()
        {
            //Arrange
            LoopsAndArrayExercises exercises = new LoopsAndArrayExercises();
            int[] x = new int[] { 1, 2, 3 };

            //Act
            int[] result = exercises.MiddleWay(x, new int[] { 4, 5, 6 });

            //Assert
            CollectionAssert.AreEqual(new int[] { 2, 5 }, result);
       }

        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object


    }
}