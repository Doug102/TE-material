using PetInfoClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;


namespace PetInfoClient.APIServices
{
    public class CustomerAPIService 
    {
        private readonly string API_URL = "https://localhost:44349/customer/";
        RestClient client = new RestClient();

        public List<Customer> GetCustomers()
        {
            List<Customer> cities = new List<Customer>();

            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Customer>> response = client.Get<List<Customer>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
    }
}
