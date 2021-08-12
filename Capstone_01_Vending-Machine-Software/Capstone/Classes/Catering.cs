using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        private List<CateringItem> items = new List<CateringItem>();



        public List<CateringItem> SetItems()
        {
            FileAccess file = new FileAccess();  // calls file access to read in file and returns list of catering items
            items = file.ReadFile();
            return items;

        }

        public List<CateringItem> GetItems()  // pulls list of catering items
        {
            return items;     
        }

        public bool CheckItem(string itemCode)
        {
            foreach (CateringItem item in items)
            {
                if (item.Code == itemCode)   // checks user input to see if it matches an item code in list
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckSoldOut(string itemCode)
        {
            foreach (CateringItem item in items)
            {
                if (item.Code == itemCode)   // checks to see if catering item selected is sold out
                {
                    if (item.Stock > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ChangeQuantity(string itemCode, int quantityBought)
        {
            foreach (CateringItem item in items)
            {
                if (item.Code == itemCode)
                {
                    if (item.Stock >= quantityBought)  // checks to see if enough product is availible for purchase and updates item stock if availible
                    {
                        item.Stock -= quantityBought;
                        return true;
                    }

                }

            }
            return false;
        }
        public decimal Purchase(string id, int quantity, decimal balance)
        {


            foreach (CateringItem item in items)
            {
                if (id == item.Code)
                {
                    decimal totalCost = quantity * item.Price;  // checks to see if enough funds are availible for purchase requested. returns total cost of purchase
                    if (totalCost <= balance)
                    {

                        return totalCost;
                    }
                }

            }
            return balance;
        }
        public CateringItem PurchaseList(string id, int quantity)  // adds properties quantity and total cost to item selected to purchase
        {
            CateringItem purchase = new CateringItem();
            purchase.Quantity = quantity;
            foreach (CateringItem item in items)
            {
                if (id == item.Code)
                {
                    purchase.TotalCost = quantity * item.Price;
                    purchase.Price = item.Price;
                    purchase.Name = item.Name;
                    purchase.Code = item.Code;
                    if (item.Type == "A")
                    {
                        purchase.Type = "Appetizer";
                    }
                    if (item.Type == "B")
                    {
                        purchase.Type = "Beverage";
                    }
                    if (item.Type == "E")
                    {
                        purchase.Type = "Entree";
                    }
                    if (item.Type == "D")
                    {
                        purchase.Type = "Dessert";
                    }


                }

            }
            return purchase;
        }






    }
}
