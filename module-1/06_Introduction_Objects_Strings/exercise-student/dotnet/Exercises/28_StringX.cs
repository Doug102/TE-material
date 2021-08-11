namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }

            else
            {
                string start = str.Substring(0, 1);
                string end = str.Substring(str.Length - 1, 1);
                string middle = "";


                if (str.Length == 1)
                {
                    return start;

                }
                else if (str.Length == 2)
                {
                    return start + end;
                }

                else
                {

                    for (int i = 1; i < str.Length - 1; i++)
                    {
                        string testString = str.Substring(i, 1);
                        if (testString != "x")
                        {
                            middle += testString;
                        }
                    }
                    return start + middle + end;
                }
            }
        }

    }
}
