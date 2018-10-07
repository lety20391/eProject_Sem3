using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtInstitute.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award
        public ActionResult AwardIndex()
        {
            return View();
        }
    }
}