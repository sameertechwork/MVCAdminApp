using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdminApp.BL;
using AdminApp.Model;
using System.Data;

using System.Web.Script.Serialization;

namespace AdminApp.Controllers
{
    public class LoginController : Controller
    {     
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel lg)
        {
            if (ModelState.IsValid)
            {
                LoginBL objLogin = new LoginBL();              
                var user = objLogin.LoginUser(lg.userName, lg.password);
                if (user != null)
                {
                    if (lg.userName == user.userName && lg.password == user.password)
                        FormsAuthentication.RedirectFromLoginPage(lg.password, true);

                    return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    ViewBag.Message = "Invalid login!";
                    ViewBag.Error = "Credentials invalid. Please try again.";
                }
            }
            else
            {
                ViewBag.Error = "Form is not valid; please review and try again.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}
