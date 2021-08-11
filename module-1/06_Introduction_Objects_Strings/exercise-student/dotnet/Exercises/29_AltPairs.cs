namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... so "kittens" yields "kien".
        AltPairs("kitten") → "kien"
        AltPairs("Chocolate") → "Chole"
        AltPairs("CodingHorror") → "Congrr"
        */
        public string AltPairs(string str)
        {
            string result = "";
            if (str.Length % 2 == 0)
            {
                for (int i = 0; i < str.Length - 1; i += 4)
                {
                    result += str.Substring(i, 2);
                }
            }
            else if ((str.Length - 1) % 4 == 0)
            {
                for (int i = 0; i < str.Length - 1; i += 4)
                {
                    result += str.Substring(i, 2);
                }
                result += str.Substring(str.Length - 1);
            }
            else
            {
                for (int i = 0; i < str.Length - 1; i += 4)
                {
                    result += str.Substring(i, 2);
                }
            }
            return result;
            
        }
    }
}
