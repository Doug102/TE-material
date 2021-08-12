using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    [TestClass]
    public class LanguageSqlDAOTests 
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=World;Trusted_Connection=True;";

        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

        [TestMethod]
        public void Test_RemoveLanguage_Result_and_Count()
        {
            //Arrange
            LanguageSqlDAO dao = new LanguageSqlDAO(ConnectionString);

            Language language = new Language();
            language.CountryCode = "USA";
            language.Name = "C#";
            language.IsOfficial = false;

            dao.AddNewLanguage(language);

            int beforeDeleteCount = GetRowCount("countrylanguage");

            //Action
            bool result = dao.RemoveLanguage(language);
            int afterDeleteCount = GetRowCount("countrylanguage");

            //Assert
            Assert.IsTrue(result, "RemoveLanguage returned false");
            Assert.AreEqual(beforeDeleteCount-1, afterDeleteCount, "Row count did not decrease.");

        }

        /// <summary>
        /// Gets the row count for a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }


    }
}
