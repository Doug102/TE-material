using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class TransferServices : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/transfers";
        API_User api_User = new API_User();


        public bool TransferTEBucks(Transfer transfer)
        {
            RestRequest request = new RestRequest(API_BASE_URL);
            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Post<bool>(request);

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

        public List<Transfer> GetTransfersForId(int accountId)
        {

            RestRequest request = new RestRequest(API_BASE_URL + $"/{accountId}");
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

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
        public bool UpdateTransferApproved(int transferId, Transfer transfer)
        {
            transfer.TransferStatusId = 2001;
            RestRequest request = new RestRequest(API_BASE_URL + $"/approved/{transferId}");
            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Put<bool>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.", response.ErrorException);
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
        public bool UpdateTransferRejected(int transferId, Transfer transfer)
        {
            transfer.TransferStatusId = 2002;
            RestRequest request = new RestRequest(API_BASE_URL + $"/rejected/{transferId}");
            request.AddJsonBody(transfer);
            IRestResponse<bool> response = client.Put<bool>(request);
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
