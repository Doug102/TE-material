using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given two Dictionaries, Dictionary<string, int>, merge the two into a new Dictionary, Dictionary<string, int> where keys in Dictionary2,
         * and their int values, are added to the int values of matching keys in Dictionary1. Return the new Dictionary.
         *
         * Unmatched keys and their int values in Dictionary2 are simply added to Dictionary1.
         *
         * ConsolidateInventory({"SKU1": 100, "SKU2": 53, "SKU3": 44} {"SKU2":11, "SKU4": 5})
         * 	 → {"SKU1": 100, "SKU2": 64, "SKU3": 44, "SKU4": 5}
         *
         */
        public Dictionary<string, int> ConsolidateInventory(Dictionary<string, int> mainWarehouse,
                                                            Dictionary<string, int> remoteWarehouse)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> kvp in mainWarehouse)
            {
                string key = kvp.Key;
                foreach (KeyValuePair<string, int> kvp2 in remoteWarehouse)
                {
                    if (key == kvp2.Key)
                    {
                        result[key] = kvp.Value + kvp2.Value;

                    }


                }

            }
            foreach (KeyValuePair<string, int> kvp in mainWarehouse)
            {
                if (!remoteWarehouse.ContainsKey(kvp.Key))
                {
                    result[kvp.Key] = kvp.Value;
                }
            }
            foreach (KeyValuePair<string, int> kvp in remoteWarehouse)
            {
                if (!mainWarehouse.ContainsKey(kvp.Key))
                {
                    result[kvp.Key] = kvp.Value;
                }
            }


            return result;
        }
    }
}
