using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;
using ComputeMidwest.Entities;
using ComputeMidwest.Entity;
using ComputeMidwest.Model;

namespace ComputeMidwest.Models
{
    public class SinglyAuthenticator
    {
        public ComputeMidwest.Entities.AccessToken GetAuthenticated(string code)
        {
            var client = new RestClient(@"https://api.singly.com");
            RestRequest request = new RestRequest(@"/oauth/access_token", Method.POST);
            request.AddParameter("code", code);
            request.AddParameter("client_id", "1126787a8dfc27ada2cebc9deedd520e");
            request.AddParameter("client_secret", "6b3afb313022fbfb04b820cdb684f913");
            IRestResponse response = client.Execute<AccessToken>(request);
            var jresponse = JsonConvert.DeserializeObject<AccessToken>(response.Content);
            return jresponse;
        }

        public void CheckUser(string account)
        {
            
        }

        public ComputeMidwest.Entities.Data GetUserFromTwitter(string accessToken)
        {
            //https://api.singly.com/profiles/twitter?access_token=my_token
            var client = new RestClient("https://api.singly.com");
            RestRequest request = new RestRequest(@"/profiles/twitter", Method.GET);
            request.AddParameter("access_token", accessToken);
            IRestResponse response = client.Execute<TwitterDetails>(request);

            var jresponse = JsonConvert.DeserializeObject<TwitterDetails>(response.Content);

            return jresponse.data;
        }
    }
}