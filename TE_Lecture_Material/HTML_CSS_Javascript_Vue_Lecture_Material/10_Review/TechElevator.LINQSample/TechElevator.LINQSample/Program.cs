using System;
using System.Collections.Generic;
using System.Linq; // This is needed for these methods

namespace TechElevator.LINQSample
{
    class Program
    {
        static void Main()
        {
            List<Person> people = GetPeople();

            people.ForEach(p => Console.WriteLine(p.FullName));
            // JS: people.forEach((p) => console.log(p));

            Person person = people.FirstOrDefault(p => p.Id == 1); // Or First() if you want it to throw an exception if not found
            // JS: const person = people.find((p) => p.id === 1);

            int index = people.FindIndex(p => p.FullName == "John Fulton"); // Only available on List
            // JS: const index = people.findIndex((p) => p.firstName === 'John' && p.lastName === 'Fulton');

            IEnumerable<Person> jsPeople = people.Where(p => p.KnowsJavaScript);
            // JS: const jsPeople = people.filter((p) => p.knowsJavaScript);

            IEnumerable<string> firstNames = people.Select(p => p.FirstName);
            // JS: const firstNames = people.map((p) => p.firstName);

            int sum = people.Aggregate(0, (total, person) => total + person.Id);
            // JS: const sum = people.reduce((total, person) => total + person.id, 0);

            // Easier LINQ versions of reduce:
            int totalIds = people.Sum(p => p.Id);
            double average = people.Average(p => p.Id);
            int max = people.Max(p => p.Id);
            int min = people.Min(p => p.Id);
        }

        private static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person(1, "Matt", "Eland"),
                new Person(2, "John", "Fulton")
            };
        }
    }
}
