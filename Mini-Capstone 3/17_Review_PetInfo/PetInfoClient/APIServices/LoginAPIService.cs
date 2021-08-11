using PetInfoClient.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoClient.APIServices
{
    public class LoginAPIService
    {
        protected static RestClient client = new RestClient();

        private readonly string API_URL = "https://localhost:44349/login/";
        private APIUser user = new APIUser();

        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public bool Login(string submittedName, string submittedPass)
        {
            LoginUser loginUser = new LoginUser { Username = submittedName, Password = submittedPass };
            RestRequest request = new RestRequest(API_URL);
            request.AddJsonBody(loginUser);
            IRestResponse<APIUser> response = client.Post<APIUser>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                if (response.Data != null && !string.IsNullOrWhiteSpace(response.Data.Message))
                {
                    throw new Exception("An error message was received: " + response.Data.Message);
                }
                else
                {
                    throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
                }
            }
            else
            {
                user.Token = response.Data.Token;
                client.Authenticator = new JwtAuthenticator(user.Token);
                return true;
            }
        }

        public void Logout()
        {
            user = new APIUser();
            client.Authenticator = null;
        }

        public bool Register(string submittedName, string submittedPass)
        {
            LoginUser loginUser = new LoginUser { Username = submittedName, Password = submittedPass };
            RestRequest request = new RestRequest(API_URL + "register");
            request.AddJsonBody(loginUser);
            IRestResponse<APIUser> response = client.Post<APIUser>(request);

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
                return true;
            }
        }

    }
}
