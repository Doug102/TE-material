namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override string Name { get; }

        public Cow() : base("moo")
        {
            Name = "Cow";
            Price = 1500;
        }
    }
}
