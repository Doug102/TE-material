using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Just when you thought it was safe to get back in the water --- Last2Revisited!!!!
         *
         * Given an array of strings, for each string, the count of the number of times that a substring length 2 appears
         * in the string and also as the last 2 chars of the string, so "hixxxhi" yields 1.
         *
         * We don't count the end substring, but the substring may overlap a prior position by one.  For instance, "xxxx"
         * has a count of 2, one pair at position 0, and the second at position 1. The third pair at position 2 is the
         * end substring, which we don't count.
         *
         * Return Dictionary<string, int>, where the key is string from the array, and its last2 count.
         *
         * Last2Revisited(["hixxhi", "xaxxaxaxx", "axxxaaxx"]) → {"hixxhi": 1, "xaxxaxaxx": 1, "axxxaaxx": 2}
         *
         */
        public Dictionary<string, int> Last2Revisited(string[] words)
        {
        
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;
                if (words[i].Length < 2)
                {
                    count = 0;
                }
                else
                {
                    for (int j = 0; j < words[i].Length - 1; j++)
                    {
                        if (words[i].Substring(j, 2) == words[i].Substring(words[i].Length - 2, 2))
                        {
                            count += 1;
                        }
                    }

                }
                if (count != 0)
                {
                    count += -1;
                }
                result[words[i]] = count;
                
            }


            return result;
            
        }
    }
}
