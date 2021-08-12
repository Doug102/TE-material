using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.APIClients
{
    public class AccountService : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/account/";

        public decimal GetBalance(int userId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + userId);
            IRestResponse<decimal> response = client.Get<decimal>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return 0M;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return 0M;
            }
            else
            {
                return response.Data;
            }
        }
    }
}
