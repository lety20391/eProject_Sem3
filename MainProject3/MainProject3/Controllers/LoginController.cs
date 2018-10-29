using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainProject3.Models;
using System.Web.Security;

namespace MainProject3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private ModelMain db = new ModelMain();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User currentUser)
        {
            //khong cho luu login cheo trinh duyet
            bool rememberMe = false;

            User searchUser = db.Users.Where(item => item.UserNick.Equals(currentUser.UserNick) && item.UserPass.Equals(currentUser.UserPass)).SingleOrDefault();
            if (searchUser != null)
            {
                //tao ticket ve thong tin User de ma hoa gui ve cookie trinh duyet
                var authTicket = new FormsAuthenticationTicket(
                    1,                             // version
                    searchUser.UserNick,                      // user name
                    DateTime.Now,                  // created
                    DateTime.Now.AddMinutes(15),   // expires
                    rememberMe,                    // persistent?
                    searchUser.Role                //Role
                 );

                //ma hoa ticket
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                return RedirectToAction("AdminCP", "Login");
            }
            ModelState.AddModelError("", "Login error");
            return View();
        }

        public ActionResult AdminCP()
        {
            bool isLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return View("AdminCP", "_Layout");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}