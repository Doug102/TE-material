using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Models
{
    public class FlowerShopOrder
    {
        public string BouquetType { get; }
        public int NumberOfRoses { get; }

        public decimal Subtotal
        {
            get
            {
                return (19.99M + (NumberOfRoses * 2.99M));
            }
        }
        public FlowerShopOrder(string bouquetType, int numberOfRoses)
        {
            BouquetType = bouquetType;
            NumberOfRoses = numberOfRoses;
        }

        public decimal DeliveryTotal(bool sameDayDelivery, string zipCode)
        {
            int zipCodeInt = int.Parse(zipCode);
            decimal deliveryTotal = 0;
            if (zipCodeInt < 10000 || zipCodeInt > 39999)
            {
                deliveryTotal = 19.99M;
                return deliveryTotal;
            }
            else if (zipCodeInt >= 10000 && zipCodeInt <= 19999)
            {
                deliveryTotal = 0M;
                return deliveryTotal;
            }
            else if (zipCodeInt >= 20000 && zipCodeInt <= 29999 && sameDayDelivery == true)
            {
                deliveryTotal = 3.99M + 5.99M;
                return deliveryTotal;
            }
            else if (zipCodeInt >= 20000 && zipCodeInt <= 29999 && sameDayDelivery == false)
            {
                deliveryTotal = 3.99M;
                return deliveryTotal;
            }
            else if (zipCodeInt >= 30000 && zipCodeInt <= 39999 && sameDayDelivery == true)
            {
                deliveryTotal = 6.99M + 5.99M;
                return deliveryTotal;
            }
            else
            {
                deliveryTotal = 6.99M;
                return deliveryTotal;
            }
        }

        public override string ToString()
        {
            return "Order - " + BouquetType + " - " + NumberOfRoses + " roses - " + Subtotal;
        }

    }


}
