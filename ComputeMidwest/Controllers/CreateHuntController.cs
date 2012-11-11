using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using ComputeMidwest;


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
            ComputeMidwest.Models.Communications comm = new Models.Communications();
            comm.PostToTwitter(huntName, Session["access_token"].ToString());
            
            
            return View();
        }
    }
}
