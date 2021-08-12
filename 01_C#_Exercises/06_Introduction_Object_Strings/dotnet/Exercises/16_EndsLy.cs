namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if it ends in "ly".
        EndsLy("oddly") → true
        EndsLy("y") → false
        EndsLy("oddy") → false
        */
        public bool EndsLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            else if (str.Substring(str.Length - 2, 2) == "ly")
            {
                return true;
            }
            return false;
        }
    }
}
