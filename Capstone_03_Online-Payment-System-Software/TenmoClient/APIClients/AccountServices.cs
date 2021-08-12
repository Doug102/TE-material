using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class AccountServices : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/accounts";

        public decimal GetBalance()
        {
            RestRequest request = new RestRequest(API_BASE_URL);
            IRestResponse<Account> response = client.Get<Account>(request);
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
                return response.Data.Balance;
            }
        }

        public int GetAccountIdFromUserId(int userId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"/{userId}");
            IRestResponse<int> response = client.Get<int>(request);
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

        public string GetUserNameByAccountId(int id)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"/users/{id}");
            IRestResponse<Account> response = client.Get<Account>(request);
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
                return response.Data.UserName;
            }

        }

       


    }
}
