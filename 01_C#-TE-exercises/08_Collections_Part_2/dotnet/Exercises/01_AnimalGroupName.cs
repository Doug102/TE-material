using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            if (animalName == "" || animalName == null)
            {
                return "unknown";
            }
            Dictionary<string, string> animalGroup = new Dictionary<string, string>();
            animalGroup.Add("rhino", "Crash");
            animalGroup.Add("giraffe", "Tower");
            animalGroup.Add("elephant", "Herd");
            animalGroup.Add("lion", "Pride");
            animalGroup.Add("crow", "Murder");
            animalGroup.Add("pigeon", "Kit");
            animalGroup.Add("flamingo", "Pat");
            animalGroup.Add("deer", "Herd");
            animalGroup.Add("dog", "Pack");
            animalGroup.Add("crocodile", "Float");

            if (!animalGroup.ContainsKey(animalName.ToLower()))
            {
                return "unknown";
            }

            foreach (string animal in animalGroup.Keys)
            {
                
                if (animalName.ToLower() == animal)
                {
                    return animalGroup[animal];
                }

            }
            return "unknown";


        }
    }
}
