namespace TechElevator.LINQSample
{
    public class Person
    {
        public Person(int id, string first, string last)
        {
            this.Id = id;
            this.FirstName = first;
            this.LastName = last;
        }

        public bool KnowsJavaScript { get; set; } = true;
        public int Id { get; }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public string FullName => FirstName + " " + LastName;
        // ^ This is the same thing as this v
        /*
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        */

    }
}