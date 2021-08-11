namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {
        public override int GetAge()
        {
            return 2;
        }

        public Cow() : base("Cow", "moo")
        {
        }
    }
}
