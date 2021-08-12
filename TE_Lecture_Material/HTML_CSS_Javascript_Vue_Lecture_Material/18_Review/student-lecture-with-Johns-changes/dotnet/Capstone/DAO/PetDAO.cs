using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PetDAO : IPetDAO
    {
        private string connectionString;

        private string sqlGetPets = "SELECT * FROM pets;";
        private string sqlGetPet = "SELECT * FROM pets WHERE id = @id;";
        private string sqlAddPet = "INSERT INTO pets (name, type, breed) " +
            "VALUES(@name, @type, @breed);";

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

                    while (reader.Read())
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

        public Pet GetPet(int petId)
        {
            Pet pet = new Pet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetPet, conn);
                    cmd.Parameters.AddWithValue("@id", petId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                         pet = ReaderToPet(reader);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                pet = new Pet();
            }

            return pet;
        }

        public bool AddPet(Pet pet)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddPet, conn);
                    cmd.Parameters.AddWithValue("@name", pet.Name);
                    cmd.Parameters.AddWithValue("@type", pet.Type);
                    cmd.Parameters.AddWithValue("@breed", pet.Breed);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        private Pet ReaderToPet(SqlDataReader reader)
        {
            Pet pet = new Pet();
            pet.Id = Convert.ToInt32(reader["id"]);
            pet.Name = Convert.ToString(reader["name"]);
            pet.Type = Convert.ToString(reader["type"]);
            pet.Breed = Convert.ToString(reader["breed"]);
            pet.Image = Convert.ToString(reader["image"]);
            pet.Age = Convert.ToInt32(reader["age"]);
            return pet;
        }
    }
}
