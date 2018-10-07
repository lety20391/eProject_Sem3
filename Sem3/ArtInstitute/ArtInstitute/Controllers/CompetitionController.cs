using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtInstitute.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult CompetitionIndex()
        {
            return View();
        }
    }
}