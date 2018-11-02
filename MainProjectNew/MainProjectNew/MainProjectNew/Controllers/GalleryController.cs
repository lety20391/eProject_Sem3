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

        public ActionResult buyPhoto(string id, string exhiID)
        {
            ViewBag.ExamID = id;
            ViewBag.ExhibitionID = exhiID;

            System.Diagnostics.Debug.WriteLine("---------------------------------");
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(exhiID);
            System.Diagnostics.Debug.WriteLine("---------------------------------");
            return View();
        }
    }
}