using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;


namespace CapstoneTests
{
   

    [TestClass]
    public class CateringTest
    {

        [TestMethod]
        public void Check_that_catering_object_is_created()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act


            //Assert
            Assert.IsNotNull(catering);
        }

        [TestMethod]
        public void CheckThatFileIsRead()
        {
            //Arrange
            Capstone.Classes.FileAccess file = new Capstone.Classes.FileAccess();

            //Act
            file.ReadFile();

            //Assert
            Assert.IsNotNull(file.ReadFile());
        }

        [TestMethod]
        public void CheckGetChange1000()
        {
            AccountBalance account = new AccountBalance();

            account.TotalBalance = 1000M;



            Assert.AreEqual("Change back: 50 twenties, 0 tens, 0 fives, 0 ones, 0 quarters, 0 dimes, 0 nickels.", account.GetChange());

        }
        [TestMethod]
        public void CheckGetChange2546_25()
        {
            AccountBalance account = new AccountBalance();

            account.TotalBalance = 2546.25M;



            Assert.AreEqual("Change back: 127 twenties, 0 tens, 1 fives, 1 ones, 1 quarters, 0 dimes, 0 nickels.", account.GetChange());

        }
        [TestMethod]
        public void CheckGetChange18_15()
        {
            AccountBalance account = new AccountBalance();

            account.TotalBalance = 18.15M;



            Assert.AreEqual("Change back: 0 twenties, 1 tens, 1 fives, 3 ones, 0 quarters, 1 dimes, 1 nickels.", account.GetChange());

        }
        [TestMethod]
        public void CheckGetChange36_40()
        {
            AccountBalance account = new AccountBalance();

            account.TotalBalance = 36.40M;



            Assert.AreEqual("Change back: 1 twenties, 1 tens, 1 fives, 1 ones, 1 quarters, 1 dimes, 1 nickels.", account.GetChange());

        }

        [TestMethod]
        public void CheckSetItems()
        {
            Catering temp = new Catering();


            Assert.IsNotNull(temp.SetItems());

        }
        [TestMethod]
        public void CheckGetItems()
        {
            Catering temp = new Catering();


            Assert.IsNotNull(temp.GetItems());

        }
        [TestMethod]

        public void TestCheckItemTrue()
        {


            Catering temp = new Catering();

            temp.SetItems();

            bool test = temp.CheckItem("D5");

            Assert.AreEqual(true, test);
        }

        [TestMethod]

        public void TestCheckItemFalse()
        {


            Catering temp = new Catering();

            temp.SetItems();

            bool test = temp.CheckItem("A6");

            Assert.AreEqual(false, test);
        }

        [TestMethod]
        public void TestCheckSoldOutFalse()
        {
            //Arrange
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                item.Stock = 0;
            }

            //Act
            bool testBool = temp.CheckSoldOut("A4");

            //Assert
            Assert.AreEqual(false, testBool);

        }
        [TestMethod]
        public void TestCheckSoldOutTrue()
        {
            //Arrange
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                item.Stock = 50;
            }

            //Act
            bool testBool = temp.CheckSoldOut("B4");

            //Assert
            Assert.AreEqual(true, testBool);

        }
        [TestMethod]
        public void TestChangeQuantityTrue()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();

           bool testBool = temp.ChangeQuantity("A1", 25);

            Assert.AreEqual(true, testBool);


        }
        [TestMethod]
        public void TestChangeQuantityFalseBoughtTooMuch()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();

            bool testBool = temp.ChangeQuantity("A1", 51);

            Assert.AreEqual(false, testBool);


        }
        [TestMethod]
        public void TestChangeQuantityFalseInvalidItemCode()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();

            bool testBool = temp.ChangeQuantity("A6", 25);

            Assert.AreEqual(false, testBool);


        }
        [TestMethod]
        public void TestPurchaseListA1()
        {
            Catering temp = new Catering();
            temp.SetItems();
            CateringItem test1 =  temp.PurchaseList("A1", 25);
            

            Assert.AreEqual("Tropical Fruit Bowl", test1.Name);
            Assert.AreEqual("Appetizer", test1.Type);
            Assert.AreEqual(25, test1.Quantity);
            Assert.AreEqual("A1", test1.Code);
            Assert.AreEqual(3.50M, test1.Price);
            Assert.AreEqual(87.50M, test1.TotalCost);
        }
        [TestMethod]
        public void TestPurchaseListD5()
        {
            Catering temp = new Catering();
            temp.SetItems();
            CateringItem test1 = temp.PurchaseList("D5", 10);


            Assert.AreEqual("Apple Pie", test1.Name);
            Assert.AreEqual("Dessert", test1.Type);
            Assert.AreEqual(10, test1.Quantity);
            Assert.AreEqual("D5", test1.Code);
            Assert.AreEqual(2.50M, test1.Price);
            Assert.AreEqual(25M, test1.TotalCost);
        }

    }

    [TestClass]
    public class BalanceTest
    {

        [TestMethod]

        public void CheckBalanceOverExceeds()
        {
            // Arrange 
            AccountBalance accountBalance = new AccountBalance();

            // Act
            accountBalance.AddMoney(6000);

            //Assert
            Assert.AreNotEqual(6000, accountBalance);
        }
    }
    [TestClass]
    public class StockTest
    {

        [TestMethod]

        public void CheckBuyQuantityOver50Fail()
        {
            // Arrange 
            Catering catering = new Catering();


            // Act
            catering.Purchase("B1", 60, 5000);

            //Assert
            Assert.AreNotEqual(catering.Purchase("B1", 60, 5000), false);
        }

        [TestMethod]

        public void CheckBuyQuantityOver50Pass()
        {
            // Arrange 
            Catering catering = new Catering();


            // Act
            catering.Purchase("E1", 45, 5000);

            //Assert
            Assert.AreNotEqual(catering.Purchase("E1", 45, 5000), true);
        }
    }

    [TestClass]
    public class WriteTest
    {


        private string fullPath = @"C:\Catering\CateringLog.txt";

        [TestMethod]
        public void WriteFileTest()
        {
            // Arrange 
            Capstone.Classes.FileAccess testAccess = new Capstone.Classes.FileAccess();


            // Act
            testAccess.WritingFile("Name Test", 0, 0);

            //Assert
            using (StreamReader sr = new StreamReader(fullPath, false))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Assert.IsNotNull(line);
                }
            }


        }
        [TestMethod]
        public void WriteFileTestItem()
        {
            // Arrange 
            Capstone.Classes.FileAccess testAccess = new Capstone.Classes.FileAccess();


            // Act
            testAccess.WritingFileItem(0, "Name Test", "Code Test", 0, 0);

            //Assert
            using (StreamReader sr = new StreamReader(fullPath, false))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Assert.IsNotNull(line);


                }
            }


        }
    }
    [TestClass]
    public class ToStringTest
    {

        [TestMethod]
        public void TestToStringA1()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                if (item.Code == "A1")
                {
                    Assert.AreEqual("ID: A1, Name: Tropical Fruit Bowl, Price: $3.50, Stock: 50", item.ToString());
                }
            }

        }
        [TestMethod]
        public void TestToStringE4()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                if (item.Code == "E4")
                {
                    Assert.AreEqual("ID: E4, Name: Beef and Gravy, Price: $5.15, Stock: 50", item.ToString());
                }
            }

        }
        [TestMethod]
        public void TestToStringSoldOutB2()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                item.Stock = 0;
                if (item.Code == "B2")
                {
                    Assert.AreEqual("ID: B2, Name: Wine, Price: $3.05, Stock: SOLD OUT", item.ToString());
                }

            }


        }
        [TestMethod]
        public void TestToStringSoldOutD3()
        {
            Catering temp = new Catering();
            List<CateringItem> test = temp.SetItems();
            foreach (CateringItem item in test)
            {
                item.Stock = 0;
                if (item.Code == "D3")
                {
                    Assert.AreEqual("ID: D3, Name: Brownies, Price: $1.10, Stock: SOLD OUT", item.ToString());
                }

            }


        }

        [TestMethod]
        public void TestPurchaseListStringE1()
        {
            Catering temp = new Catering();
            temp.SetItems();
            CateringItem test = temp.PurchaseList("E1", 26);

            Assert.AreEqual("26, Entree, Baked Chicken, $8.85, $230.10", test.PurchaseListString());


        }

        [TestMethod]
        public void TestPurchaseListStringA3()
        {
            Catering temp = new Catering();
            temp.SetItems();
            CateringItem test = temp.PurchaseList("A3", 14);

            Assert.AreEqual("14, Appetizer, Bacon Wrapped Shrimp, $4.15, $58.10", test.PurchaseListString());


        }
    }
    [TestClass]
    public class SalesReportTest
    {
        private string fullPath = @"C:\Catering\TotalSales.rpt";

        [TestMethod]
        public void TestSalesReport()
        {
            Capstone.Classes.FileAccess file = new Capstone.Classes.FileAccess();
            file.SalesReport("TEST", 0, 0);

            using (StreamReader sr = new StreamReader(fullPath))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Assert.IsNotNull(line);


                }
            }

        }
        [TestMethod]
        public void TestTotalSalesReport()
        {
            Capstone.Classes.FileAccess file = new Capstone.Classes.FileAccess();
            file.TotalSalesReport("TEST", 0);

            using (StreamReader sr = new StreamReader(fullPath))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Assert.IsNotNull(line);


                }
            }

        }


    }

    
}
