namespace PetInfo
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set;}
        public string Breed { get; set; }

        public Pet(int id, string name, string type,
            string breed)
        {
            Id = id;
            Name = name;
            Type = type;
            Breed = breed;
        }

        public Pet(string name, string type,
            string breed)
        {
            Name = name;
            Type = type;
            Breed = breed;
        }

        public Pet()
        {

        }

        public override string ToString()
        {
            return Id + " - " + Name + " - " + Type + " - " + Breed;
        }
    }
}
