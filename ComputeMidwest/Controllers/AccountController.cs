using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using StructureMap;
using WebMatrix.WebData;

using ComputeMidwest.Models;
using RestSharp;
using Newtonsoft.Json;
using ComputeMidwest.Model;
using ComputeMidwest.Entity;

namespace ComputeMidwest.Controllers
{
       
    public class AccountController : Controller
    {
        private readonly AccountModel _accountModel;

        public AccountController()
        {
            _accountModel = ObjectFactory.GetInstance<AccountModel>();
        }

        //
        // GET: /Account/Login
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Facebook, string Twitter)
        {
            if (Facebook != null )
            {
                Session["account_type"] = "Facebook";                
                return Redirect("https://api.singly.com/oauth/authenticate?client_id=1126787a8dfc27ada2cebc9deedd520e&scope=manage_pages&redirect_uri=http://hunt.nicfog.com:9999/account/authenticated&service=facebook");
            }
            else
            {
                Session["account_type"] = "Twitter";
                return Redirect("https://api.singly.com/oauth/authenticate?client_id=1126787a8dfc27ada2cebc9deedd520e&redirect_uri=http://hunt.nicfog.com:9999/account/authenticated&service=twitter");             
            }
        }
                
        public ActionResult Authenticated(string code)
        {
            
            Session["code"] = code;
            var sa = new SinglyAuthenticator();
            var authToken = sa.GetAuthenticated(code);
            Session["access_token"] = authToken.access_token;
            Session["account"] = authToken.account;
            
            switch (Session["account_type"].ToString())
            {
                case "Facebook":
                    var facebookresponse = sa.GetUserFromFacebook(Session["access_token"].ToString());
                    Session["name"] = facebookresponse.name;
                    Session["image"] = facebookresponse.thumbnail_url;
                    break;
                case "Twitter":
                    var response = sa.GetUserFromTwitter(Session["access_token"].ToString());
                    Session["name"] = response.name;
                    break;
            }
            
            var userExist = _accountModel.GetAccountByAccountToken(Session["access_token"].ToString(), Session["account_type"].ToString());
            if (userExist != null)
            {
                var user = sa.GetUserFromTwitter(Session["access_token"].ToString());
                _accountModel.CreateAccount(user.name, Session["account_type"].ToString(), null);
            }
            else
            {
                return View("Index", "Home");
            }

            ViewBag.UserName = Session["name"].ToString();
            ViewBag.Image = Session["image"].ToString();
            ViewBag.Code = code;
            ViewBag.Response = authToken.account;

            return View();
        }
        

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
