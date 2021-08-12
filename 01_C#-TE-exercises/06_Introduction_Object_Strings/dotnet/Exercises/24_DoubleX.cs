namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
        DoubleX("axxbb") → true
        DoubleX("axaxax") → false
        DoubleX("xxxxx") → true
        */
        public bool DoubleX(string str)
        {
            bool tOrF = false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if ((str.Substring(i, 1) == "x") && (str.Substring(i, 2) == "xx"))
                {
                    tOrF = true;
                    break;
                }
                else if ((str.Substring(i, 1) == "x") && (str.Substring(i, 2) != "xx"))
                {
                    tOrF = false;
                    break;
                }
                else
                {
                    tOrF = false;
                }

            }
            return tOrF;
            


        }
    }
}
