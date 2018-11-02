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
            List<ShortExhibitionInfo> shortInfo = db.Exhibitions.Select(item => new ShortExhibitionInfo() {
                ExhibitionID = item.ExhibitionID,
                Detail = item.Detail,
                Country = item.Country,
                StartDate = item.StartDate,
                firstImagePath = db.Exams.Where(item2 => item2.IDExhibition.Equals(item.ExhibitionID)).Select(item2 => item2.Path).FirstOrDefault()

            }).ToList();
            return View(shortInfo);
        }

        public ActionResult getGallery(string id)
        {
            //List<String> listImg = db.Exams.Where(item => item.IDExhibition.Equals(id)).Select(item => item.Path).Take(9).ToList();

            return View(db.Exams.Where(item => item.IDExhibition.Equals(id)).ToList());
        }

        public ActionResult getPhoto(string id, string exhiID)
        {
            ViewBag.ExamID = id;
            ViewBag.ExhibitionID = exhiID;
            Exam searchExam = db.Exams.Find(id);

            if (!User.Identity.IsAuthenticated)
            {
                
                var objWrapper = new Tuple<Customer, Exam>(new Customer(), searchExam);
                return View(objWrapper);
            }
            else
            {
                List<Comment> listComment = db.Comments.Where(item => item.MainID.Equals(id) && item.Status == true).OrderBy(item => item.num).ToList();
                var objWrapper = new Tuple<List<Comment>, Exam>(listComment, searchExam);
                return View("getPhoto4Staff", objWrapper);
            }
        }

        [HttpPost]
        public ActionResult getPhoto(Customer newCustomer)
        {
            db.Customers.Add(newCustomer);
            db.SaveChanges();

            Customer searchCustomer = db.Customers.Where(item => item.Name.Equals(newCustomer.Name) && item.Phone.Equals(newCustomer.Phone) && item.Address.Equals(newCustomer.Address)).First();
            Submit newSubmit = new Submit();
            newSubmit.Entity1ID = searchCustomer.CustomerID;
            newSubmit.Entity2ID = newCustomer.IDExam;
            newSubmit.Type = "Customer-Exam";
            newSubmit.time = DateTime.Now;

            db.Submits.Add(newSubmit);
            db.SaveChanges();

            return Content("Success");
        }

    }
}