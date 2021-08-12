using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment.Models;

namespace Assessment.Tests
{
    [TestClass]
    public class FlowerShopOrderTest
    {
        [TestMethod]
        public void DeliveryTotalTest0DeliveryTotalSameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(true, "10256");
            Assert.AreEqual(0M, result);
                        
        }
        [TestMethod]
        public void DeliveryTotalTest0DelievryTotalNotSameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(false, "10634");
            Assert.AreEqual(0M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest699DeliverySameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(true, "30695");
            Assert.AreEqual(12.98M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest699DeliveryNotSameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(false, "35692");
            Assert.AreEqual(6.99M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest399DeliverySameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(true, "25621");
            Assert.AreEqual(9.98M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest399DeliveryNotSameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(false, "26213");
            Assert.AreEqual(3.99M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest1999DeliverySameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(true, "45854");
            Assert.AreEqual(19.99M, result);

        }
        [TestMethod]
        public void DeliveryTotalTest1999DeliveryNotSameDay()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.DeliveryTotal(false, "9562");
            Assert.AreEqual(19.99M, result);

        }
        [TestMethod]
        public void SubTotalTest5Roses()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 5);
            decimal result = test.Subtotal;
            Assert.AreEqual(34.94M, result);

        }
        [TestMethod]
        public void SubTotalTest0Roses()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 0);
            decimal result = test.Subtotal;
            Assert.AreEqual(19.99M, result);

        }
        [TestMethod]
        public void SubTotalTest2Roses()
        {
            FlowerShopOrder test = new FlowerShopOrder("standard bouquet", 2);
            decimal result = test.Subtotal;
            Assert.AreEqual(25.97M, result);

        }


    }
}
