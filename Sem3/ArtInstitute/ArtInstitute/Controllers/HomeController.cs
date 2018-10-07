using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtInstitute.Controllers
{
    public class HomeController : Controller
    {
        //Quan ly Login va Public Data
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}