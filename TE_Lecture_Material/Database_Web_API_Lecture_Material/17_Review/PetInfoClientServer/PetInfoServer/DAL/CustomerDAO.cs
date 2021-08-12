using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.DAL
{
    public class CustomerDAO : ICustomerDAO
    {
        private string connectionString;
        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {
            Customer customer = new Customer
            {
                Name = "TestName",
                Email = "Doug@email.com"
            };
            //todo fix dao method
            return new List<Customer> { customer };
        }
    }
}
