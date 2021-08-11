using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {

        public override int GetAge()
        {
            return 1;
        }

        public Chicken() : base("Chicken", "cluck")
        {
        }



        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}
