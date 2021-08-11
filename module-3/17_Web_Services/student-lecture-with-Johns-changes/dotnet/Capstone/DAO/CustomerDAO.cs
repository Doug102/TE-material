using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CustomerDAO : ICustomerDAO
    {

        private string connectionString;

        private string sqlGetCustomers = "SELECT * FROM customers;";
        private string sqlGetCustomer = "SELECT * FROM customers WHERE id = @id;";
        private string sqlAddCustomer = "INSERT INTO customers (name, email, phone) " +
            "VALUES(@name, @email, @phone);";

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCustomers, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer pet = ReaderToCustomer(reader);
                        customers.Add(pet);

                    }
                }
            }
            catch (Exception ex)
            {
                customers = new List<Customer>();
            }

            return customers;
        }

        public Customer GetCustomer(int customerId)
        {
            Customer pet = new Customer();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCustomer, conn);
                    cmd.Parameters.AddWithValue("@id", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        pet = ReaderToCustomer(reader);

                    }
                }
            }
            catch (Exception ex)
            {
                pet = new Customer();
            }

            return pet;
        }



        public bool AddCustomer(Customer customer)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddCustomer, conn);
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);

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

        private Customer ReaderToCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.Id = Convert.ToInt32(reader["id"]);
            customer.Name = Convert.ToString(reader["name"]);
            customer.Phone = Convert.ToString(reader["phone"]);
            customer.Email = Convert.ToString(reader["email"]);
            return customer;
        }
    }
}
