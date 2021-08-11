using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;
using PetInfo.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace PetInfoTest
{
    [TestClass]
    public class PetDAOTest
    {
        PetDAO petDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=PetInfo;Integrated Security=True";
        private TransactionScope tran;


        [TestInitialize]
        public void Setup()
        {
            tran = new TransactionScope();

            // Arrange
            petDAO = new PetDAO(connectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void PetDAOConstructor()
        {
            Assert.IsNotNull(petDAO);
        }

        [TestMethod]
        [DataRow("Dog 1", "dog", "All American")]
        public void PetDAOAddPet(string name, string type, string breed)
        {
            //Act
            petDAO.AddPet(name, type, breed);
            List<Pet> pets = petDAO.GetPets();

            //Assert
            Assert.AreEqual(name, pets[pets.Count - 1].Name);
        }

        [TestMethod]
        [DataRow("Dog 1", "dog", "All American")]
        public void PetDAOAddPetRowCount(string name, string type, string breed)
        {
            //Act
            List<Pet> pets = petDAO.GetPets();
            int count = pets.Count;

            petDAO.AddPet(name, type, breed);

            pets = petDAO.GetPets();

            //Assert
            Assert.AreEqual(count + 1, pets.Count);
        }

        [TestMethod]
        public void PetDAODeletePet()
        {
            int testId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO pet (name, type, breed) VALUES " +
                    "('Test Dog', 'dog', 'All American');", conn);

                int count = cmd.ExecuteNonQuery();

                Assert.IsTrue(count > 0);

                cmd = new SqlCommand(
                    "SELECT id FROM pet WHERE name = 'Test Dog';", conn);

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    testId = Convert.ToInt32(reader["id"]);
                }
            }

            bool result = false;

            if (testId > 0)
            {
                result = petDAO.DeletePet(testId);
            }

            Assert.IsTrue(result);
        }
    }
}

