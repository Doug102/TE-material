using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private readonly string connectionString;

        private string sqlGetCountries = "SELECT * FROM country;";
            

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Country> GetCountries()
        {
            IList<Country> result = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCountries, conn);
                    SqlDataReader reader =  cmd.ExecuteReader();

                    while(reader.Read() == true)
                    {
                        Country country = new Country();
                        country.Code = Convert.ToString(reader["code"]);
                        country.Name = Convert.ToString(reader["name"]);
                        country.Continent = Convert.ToString(reader["continent"]);

                        result.Add(country);
                       
                    }
                }

            }
            catch (Exception ex)
            {
                result = new List<Country>();
            }
            return result;
            
        }

        public IList<Country> GetCountries(string continent)
        {
            throw new NotImplementedException();
        }
    }
}
