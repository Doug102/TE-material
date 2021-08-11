using RestSharp;
using System;
using System.Collections.Generic;

namespace AuctionApp
{
    public class APIService
    {
        public const string API_URL = "http://localhost:3000/auctions";
        public IRestClient client = new RestClient();

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            return response.Data;
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest request = new RestRequest(API_URL + "/" + auctionId);
            IRestResponse<Auction> response = client.Get<Auction>(request);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            RestRequest request = new RestRequest(API_URL + "?title_like=" + searchTitle);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest(API_URL + "?currentBid_lte=" + searchPrice);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            return response.Data;
        }
    }
}
