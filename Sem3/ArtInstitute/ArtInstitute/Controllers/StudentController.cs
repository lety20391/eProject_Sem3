﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtInstitute.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentIndex()
        {
            return View();
        }
    }
}