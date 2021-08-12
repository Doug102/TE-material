using Capstone.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class ParentTest
    {
        private TransactionScope trans;

        protected string connectionString;
        protected VenueDAO venueDAO;

        public ParentTest()
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            connectionString = configuration.GetConnectionString("Project");
        }

        [TestInitialize]
        public void Setup()
        {
            trans = new TransactionScope();
            venueDAO = new VenueDAO(connectionString);
            string sql = File.ReadAllText("capstone_test_script.sql");      // read text file for test data
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();         // execute script to set test data


            }
        }

        [TestCleanup]
        public void Reset()
        {
            trans.Dispose();
        }
    }
}
