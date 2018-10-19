using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VietPhap2018.Models;

namespace VietPhap2018.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AppDB db = new AppDB();
        public ActionResult Index()
        {
            return View(db.tbReport.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User currentUser)
        {
            if (currentUser.UserName.Equals("FOSM") && currentUser.UserPass.Equals("f0Sm"))
            {
                FormsAuthentication.SetAuthCookie(currentUser.UserName, false);
                return RedirectToAction("Index", "Report");
            }
            ModelState.AddModelError("", "Login error");
            return View();
        }
    }
}