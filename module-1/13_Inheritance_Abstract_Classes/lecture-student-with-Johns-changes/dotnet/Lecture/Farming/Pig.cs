namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override string Name { get; }

        public Pig() : base("oink")
        {
            Price = 300;
            Name = "Pig";
        }
    }
}
