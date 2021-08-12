using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int AddCity(City city)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, @district, @population);  " +
                       "SELECT SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    result = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (SqlException ex)
            {
                result = 0;
            }

            return result;
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //good
                    string sql_command = "SELECT * FROM city WHERE countryCode = @countryCode;";
                    SqlCommand cmd = new SqlCommand(sql_command, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    ////bad
                    //string sql_command = "SELECT * FROM city WHERE countryCode = '" + countryCode + "';";
                    //SqlCommand cmd = new SqlCommand(sql_command, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = ConvertReaderToCity(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                cities = new List<City>();
            }

            return cities;
        }

        private City ConvertReaderToCity(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }
    }
}
