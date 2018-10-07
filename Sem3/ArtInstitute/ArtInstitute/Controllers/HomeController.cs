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
        public ActionResult HomeIndex()
        {
            return View();
        }

        public ActionResult CallUserIndex()
        {
            var ctrl = new UserController();
            ctrl.ControllerContext = ControllerContext;
            //call action
            return ctrl.UserIndex();
        }
    }
}