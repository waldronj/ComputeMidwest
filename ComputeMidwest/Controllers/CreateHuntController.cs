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
            HuntModel hm = new HuntModel(new EntityModelContainer(), new HuntNotifier(new PusherProvider("31452", "04af48f0bd881f9f9737", "0bbb6f45596775fa5d2d")));

            AccountModel am = new AccountModel(new EntityModelContainer());
            Account act = am.GetAccountByAccountToken(Session["access_token"].ToString(), Session["account_type"].ToString());
            Hunt hunt = new Hunt()
            {
                Creator = act,
                Name = huntName,
                Description = description
            };
            hm.CreateHunt(act, hunt);
            ComputeMidwest.Models.Communications comm = new Models.Communications();

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
