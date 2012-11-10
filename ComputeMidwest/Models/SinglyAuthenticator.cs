using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

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
            IRestResponse response = client.Execute<ComputeMidwest.Entities.AccessToken>(request);
            var jresponse = JsonConvert.DeserializeObject<ComputeMidwest.Entities.AccessToken>(response.Content);
            return jresponse;
        }
    }
}