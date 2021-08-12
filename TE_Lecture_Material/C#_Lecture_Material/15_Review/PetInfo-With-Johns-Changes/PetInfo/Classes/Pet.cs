namespace PetInfo
{
    public class Pet
    {
        private string name;

        public int Id { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
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

        public override string ToString()
        {
            return Name + " - " + Type + " - " + Breed;
        }
    }
}
