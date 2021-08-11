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
    public class CitySQLDALTests 
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
        public void AddCity_Should_IncreaseCountBy1()
        {
            // Arrange
            City city = new City();
            city.CountryCode = "USA";
            city.Name = "Doesn't matter";
            city.Population = 1;
            city.District = "Doesn't matter";
            CitySqlDAO dao = new CitySqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("city");


            //Act
            dao.AddCity(city);


            //Assert
            int endingRowCount = GetRowCount("city");
            Assert.AreEqual(startingRowCount+1, endingRowCount);
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
