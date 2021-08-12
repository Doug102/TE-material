using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PetInfo.Classes.DAO
{
    public class PetDAO
    {

        private string connectionString;

        private string sqlGetPets = "SELECT * FROM pet;";

        private string sqlAddPet = "INSERT INTO pet ( name, type, breed) " +
            "VALUES (@name, @type, @breed);";

        private string sqlDeletePet = "DELETE FROM pet " +
            "WHERE id = @id;";

        public PetDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pet> GetPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetPets, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pet pet = new Pet();
                    pet.Id = Convert.ToInt32(reader["id"]);
                    pet.Name = Convert.ToString(reader["name"]);
                    pet.Type = Convert.ToString(reader["type"]);
                    pet.Breed = Convert.ToString(reader["breed"]);
                    pets.Add(pet);
                }
            }

            return pets;

        }

        public Pet GetPet(int petId)
        {
            Pet pet = new Pet();
            return pet;

        }

        public bool AddPet(string name, string type, string breed)
        {
            Pet pet = new Pet(name, type, breed);
            return AddPet(pet);
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
                if(count >0)
                {
                    result = true;
                }
                    
            }
            return result;
        }
    }
}
