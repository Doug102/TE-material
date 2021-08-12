namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override string Name { get; }

        public Pig() : base("oink")
        {
            Name = "Pig";
            Price = 300;
        }
    }
}
