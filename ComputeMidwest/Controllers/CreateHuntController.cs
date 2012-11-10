using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace ComputeMidwest.Controllers
{
    public class CreateHuntController : Controller
    {
        //
        // GET: /CreateHunt/

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string huntName)
        {
            var client = new RestClient(@"https://api.singly.com");
            RestRequest request = new RestRequest(@"/types/statuses?access_token={token}&to=twitter", Method.POST);
            request.AddParameter("token", Session["access_token"], ParameterType.UrlSegment);
            request.AddParameter("status", huntName);
            
            IRestResponse response = client.Execute(request);


            return View();
        }
    }
}
