using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // all files for this application should in this directory
        // you will likley need to create it on your computer

        private string filePath = @"C:\Catering\cateringsystem.csv";

        // This class should contain any and all details of access to files

        public List<CateringItem> ReadFile()  // reads in csv file and splits lines to make a list of catering items
        {
            List<CateringItem> items = new List<CateringItem>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('|');

                    CateringItem item = new CateringItem();

                    item.Code = split[0];
                    item.Name = split[1];
                    item.Price = decimal.Parse(split[2]);
                    item.Type = split[3];

                    items.Add(item);

                }
            }
            return items;

        }
            //Keeping the log.
            public void WritingFile(string writeMethod, decimal moneySpent, decimal balance)
            {
                AccountBalance accountBalance = new AccountBalance();

                string WritingFileString()
                {
                    return $"{writeMethod} ${moneySpent} ${balance}";
                }
                //    string directory = Environment.CurrentDirectory;
                //    string filename = "CateringLog.txt";
                //    string fullPath = Path.Combine(directory, filename);

                string fullPath = @"C:\Catering\CateringLog.txt";

                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.Write(DateTime.Now + "  ");
                    sw.Write(WritingFileString());
                    sw.WriteLine("");
                }
            }


            public void WritingFileItem(int quantity, string name, string id, decimal cost, decimal totalbalance)
            {
                    AccountBalance accountBalance = new AccountBalance();

                    string WritingFileStringItem()
                    {
                        return $"{quantity} {name} {id} ${cost} ${totalbalance}";
                    }


                    string fullPath = @"C:\Catering\CateringLog.txt";

                    using (StreamWriter sw = new StreamWriter(fullPath, true))
                    {
                        sw.Write(DateTime.Now + "  ");
                        sw.Write(WritingFileStringItem());
                        sw.WriteLine("");
                    }
            }


        //Reports the item name, # of items, and cost of total items to Total Sales Report.
        public void SalesReport (string name, int quantity, decimal cost)
        {
            string SalesReportString()
            {
                return $" {name} | {quantity} | ${cost} ";
            }

            string fullPath = @"C:\Catering\TotalSales.rpt";

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.Write("");
                sw.Write(SalesReportString());
                sw.WriteLine("");
            }
        }

        //Reports the total money spent to Total Sales Report.
        public void TotalSalesReport(string name, decimal cost)
        {
            string TotalSalesReportString()
            {
                return $" {name}  ${cost} ";
            }

            string fullPath = @"C:\Catering\TotalSales.rpt";

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.Write("");
                sw.Write(TotalSalesReportString());
                sw.WriteLine("");
            }
        }



    }
}
