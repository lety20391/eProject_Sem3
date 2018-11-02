using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainProjectNew.Models;

namespace MainProjectNew.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ModelMain db = new ModelMain();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getGallery(string id)
        {
            //List<String> listImg = db.Exams.Where(item => item.IDExhibition.Equals(id)).Select(item => item.Path).Take(9).ToList();

            return View(db.Exams.Where(item => item.IDExhibition.Equals(id)).ToList());
        }

        public ActionResult buyPhoto(string id)
        {
            return View();
        }
    }
}