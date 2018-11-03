using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProjectNew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentErr()
        {
            return View("StudentErr", "_Layout");
        }

        public ActionResult Contact()
        {
            return View("Contact", "_Layout");
        }

    }
}