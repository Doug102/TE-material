using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class UsersServices : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/users";
        API_User api_User = new API_User();

        public List<API_User> GetUsers()
        {
            RestRequest request = new RestRequest(API_BASE_URL);
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
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
        public Account GetCurrentUser(int userId)
        {

            RestRequest request = new RestRequest(API_BASE_URL + $"/{userId}");
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
                return response.Data;
            }

        }
       
    }
}
