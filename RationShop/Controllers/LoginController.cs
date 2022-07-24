using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RationShop.Models;
using System.Web.Security;

namespace RationShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View("Signin");
        }

        public ActionResult AfterSignIn(LoginUser user, string ReturnUrl)
        {
            if (Check(user))
            {

                FormsAuthentication.SetAuthCookie(user.username, false);


                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return Redirect("/Shop/Index");
                }
            }
            else
            {

                ViewBag.message = "UserName / Password is invalid";
                return View("Signin");
            }
        }

        private bool Check(LoginUser user)
        {
            if (user.username == "Aniket" && user.password == "aniket@123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Shop/Index");
        }
    }
}