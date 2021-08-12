using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    class UserServices : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/user/";

        public List<API_User> GetUserList(int userId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + "listother/" + userId);
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
            List<API_User> empty = new List<API_User>();

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return empty;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return empty;
            }
            else
            {
                return response.Data;
            }
        }
    }
}
