using PetInfoClient.Models;
using PetInfoServer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetInfoServer.DAL
{
    public class PetDAO :IPetDAO
    {
        private string connectionString;

        private string sqlGetPets = "SELECT * FROM pet;";

        private string sqlAddPet = "INSERT INTO pet ( name, type, breed, owner) " +
            "VALUES (@name, @type, @breed, @owner);";

        private string sqlDeletePet = "DELETE FROM pet " +
            "WHERE id = @id;";

        public PetDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pet> GetPets()
        {
            List<Pet> pets = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetPets, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Pet pet = ReaderToPet(reader);
                        pets.Add(pet);

                    }

                }
            }
            catch (Exception ex)
            {
                pets = new List<Pet>();
            }

            return pets;
        }

        public bool AddPet(Pet pet)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddPet, conn);

                cmd.Parameters.AddWithValue("@name", pet.Name);
                cmd.Parameters.AddWithValue("@type", pet.Type);
                cmd.Parameters.AddWithValue("@breed", pet.Breed);
                cmd.Parameters.AddWithValue("@owner", pet.Owner);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    result = true;
                }

            }
            return result;
        }

        public bool DeletePet(int id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlDeletePet, conn);

                cmd.Parameters.AddWithValue("@id", id);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }

            }
            return result;
        }

        private Pet ReaderToPet(SqlDataReader reader)
        {
            Pet pet = new Pet();
            pet.Id = Convert.ToInt32(reader["id"]);
            pet.Name = Convert.ToString(reader["Name"]);
            pet.Type = Convert.ToString(reader["Type"]);
            pet.Breed = Convert.ToString(reader["Breed"]);
            pet.Owner =  Convert.ToInt32(reader["Owner"]);
            return pet;
        }
    }
}
