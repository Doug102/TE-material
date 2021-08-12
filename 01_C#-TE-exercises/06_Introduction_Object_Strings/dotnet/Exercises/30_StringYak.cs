namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed.
        The "yak" strings will not overlap.
        StringYak("yakpak") → "pak"
        StringYak("pakyak") → "pak"
        StringYak("yak123ya") → "123ya"
        */
        public string StringYak(string str)
        {
            string result = "";

            if (!str.Contains("yak"))
            {
                return str;
            }
            else if (str.Length == 3 && str == "yak")
            {
                return "";
            }
            else
            {
                if (str.StartsWith("yak"))
                {
                    result = str.Substring(3, str.Length - 3);

                    if (result.EndsWith("yak"))
                    {
                        result = result.Substring(0, result.Length - 3);
                    }
                }
                else if (str.EndsWith("yak"))
                {
                    result = str.Substring(0, str.Length - 3);
                }
                else
                {
                    result = str;
                }
                if (!result.Contains("yak"))
                {
                    return result;
                }
                else
                {
                    int index = result.IndexOf("yak");
                    result = result.Substring(0, index) + result.Substring(index + 3, (result.Length - index) - 3);
                    if (!result.Contains("yak"))
                    {
                        return result;
                    }
                    else
                    {
                        int indexTwo = result.IndexOf("yak");
                        result = result.Substring(0, indexTwo) + result.Substring(indexTwo + 3, (result.Length - indexTwo) - 3);
                        if (!result.Contains("yak"))
                        {
                            return result;
                        }
                    }
                }






            }
            return "";

        }
    }
}
