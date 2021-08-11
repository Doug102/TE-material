using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; } = 50;
        public int Quantity { get; set; } = 0;
        public decimal TotalCost { get; set; } = 0;

        public override string ToString()   // overrides string method for item display, displays SOLD OUT for stock if item stock = 0
        {
            if (Stock > 0)
            {
                return $"ID: {Code}, Name: {Name}, Price: ${Price}, Stock: {Stock}";
            }
            else
            {
                return $"ID: {Code}, Name: {Name}, Price: ${Price}, Stock: SOLD OUT";
            }
        }
        public string PurchaseListString()   // creates new string method once item is purchased, includes properties quantity and total cost
        {
            return $"{Quantity}, {Type}, {Name}, ${Price}, ${TotalCost}";
        }
    }
}
