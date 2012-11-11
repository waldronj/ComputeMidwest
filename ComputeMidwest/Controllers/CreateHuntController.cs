using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using ComputeMidwest;
using ComputeMidwest.Model;
using ComputeMidwest.Entity;
using PusherRESTDotNet;
using StructureMap;


namespace ComputeMidwest.Controllers
{
    public class CreateHuntController : Controller
    {
        private readonly AccountModel _accountModel;
        private readonly HuntModel _huntModel;

        public CreateHuntController()
        {
            _accountModel = ObjectFactory.GetInstance<AccountModel>();
            _huntModel = ObjectFactory.GetInstance<HuntModel>();
        }

        //
        // GET: /CreateHunt/
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string huntName, string description)
        {
                        
            Account act = _accountModel.GetAccountByAccountToken(Session["account"].ToString(), Session["account_type"].ToString());
            var hunt = new Hunt()
            {
                Creator = act,
                Name = huntName,
                Description = description
            };
            _huntModel.CreateHunt(act, hunt);

            var comm = new Models.Communications();

            switch (Session["account_type"].ToString())
            {
                case "Facebook":
                    comm.PostToFacebook(huntName, Session["access_token"].ToString());
                    break;
                case "Twitter":
                    comm.PostToTwitter(huntName, Session["access_token"].ToString());
                    break;

            }
            
            
            return View();
        }
    }
}
