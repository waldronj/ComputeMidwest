using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using ComputeMidwest;
using ComputeMidwest.Model;
using ComputeMidwest.Entity;


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
        public ActionResult Index(string huntName, string description)
        {
            HuntModel hm = new HuntModel(new EntityModelContainer(), new HuntNotifier()); 
            ComputeMidwest.Models.Communications comm = new Models.Communications();
            comm.PostToTwitter(huntName, Session["access_token"].ToString());
            AccountModel am = new AccountModel(new EntityModelContainer());
            Account act = am.GetAccountByAccountToken(Session["access_token"].ToString(), Session["account_type"].ToString());
            Hunt hunt = new Hunt()
            {
                Name = huntName,
                Description = description
            };
            hm.CreateHunt(act, hunt);
            
            
            return View();
        }
    }
}
