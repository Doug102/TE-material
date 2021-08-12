using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ICustomerDAO
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        bool AddCustomer(Customer customer);
    }
}
