using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace ComputeMidwest.Models
{
    public class Communications
    {
        public void PostToTwitter(string huntName, string accessToken)
        {
            var client = new RestClient(@"https://api.singly.com");
            RestRequest request = new RestRequest(@"/types/statuses", Method.POST);
            request.AddParameter("access_token", accessToken);
            request.AddParameter("body", huntName);
            request.AddParameter("to", "twitter");

            IRestResponse response = client.Execute(request);
        }
        
        public void PostToFacebook(string huntName, string accessToken)
        {
            var client = new RestClient("https://api.singly.com");
            RestRequest request = new RestRequest(@"/types/statuses", Method.POST);
            request.AddParameter("access_token", accessToken);
            request.AddParameter("body", huntName);
            request.AddParameter("to", "facebook");
            IRestResponse response = client.Execute(request);
        }
        
        public void PostToSocial(string huntName, string accessToken)
        {
            var client = new RestClient("https://api.singly.com");
            RestRequest request = new RestRequest(@"/types/statuses", Method.POST);
            request.AddParameter("access_token", accessToken);
            request.AddParameter("body", huntName);
            request.AddParameter("to", "facebook,twitter");
            IRestResponse response = client.Execute(request);
        }
    }
}