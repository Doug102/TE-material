using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    class TransferService : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/transfer/";

        public bool CreateNewSendTransfer(Transfer transfer)
        {
            RestRequest request = new RestRequest(API_BASE_URL);
            request.AddJsonBody(transfer);
            IRestResponse response = client.Post(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occured - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - recieved non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return true;
            }
        }

        public bool CreateNewRequest(Transfer transfer)
        {
            RestRequest request = new RestRequest(API_BASE_URL + "request");
            request.AddJsonBody(transfer);
            IRestResponse response = client.Post(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occured - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - recieved non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return true;
            }
        }

        public List<Transfer> ListTransfersByUserId(int userId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"user/{userId}");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return new List<Transfer>();
            }
            else if (!response.IsSuccessful)
            {
                return new List<Transfer>();
            }
            else
            {
                return response.Data;
            }
        }

        public List<Transfer> ListPendingTransfersByUserId(int userId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"user/pending/{userId}");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return new List<Transfer>();
            }
            else if (!response.IsSuccessful)
            {
                return new List<Transfer>();
            }
            else
            {
                return response.Data;
            }
        }

        public bool ApproveOrRejectRequest(Transfer transfer)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"user/respondpending");
            request.AddJsonBody(transfer);
            IRestResponse response = client.Put(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occured - unable to reach server.");
                return false;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - recieved non-success response: " + (int)response.StatusCode);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
