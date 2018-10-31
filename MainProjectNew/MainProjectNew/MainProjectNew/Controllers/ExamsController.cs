using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainProjectNew.Models;

namespace MainProjectNew.Controllers
{
    public class ExamsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Award).Include(e => e.Competition).Include(e => e.Exhibition).Include(e => e.Student);
            return View("Index", "_Layout",exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View("Details", "_Layout",exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID");
            ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail");
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail");
            ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name");
            return View("Create", "_Layout");
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult Create([Bind(Include = "ExamID,num,Path,Quotation,Story,IDStudent,IDCompetition,IDExhibition,Mark,IDAward,ChangeDescription,Status,MoneyReturn,Price,Improvement")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return Content("Create Succesfully");
            }

            ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID", exam.IDAward);
            ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail", exam.IDCompetition);
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", exam.IDExhibition);
            ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name", exam.IDStudent);
            return Content("Create Failed");
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID", exam.IDAward);
            ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail", exam.IDCompetition);
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", exam.IDExhibition);
            ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name", exam.IDStudent);
            return View("Edit", "_Layout",exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamID,num,Path,Quotation,Story,IDStudent,IDCompetition,IDExhibition,Mark,IDAward,ChangeDescription,Status,MoneyReturn,Price,Improvement")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID", exam.IDAward);
            ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail", exam.IDCompetition);
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", exam.IDExhibition);
            ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name", exam.IDStudent);
            return View("Edit", "_Layout",exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View("Delete", "_Layout",exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase ImageFile)
        //{
        //    //check Empty File
        //    if (ImageFile.ContentLength > 0)
        //    {
        //        //check image type
        //        if (ImageFile.ContentType.ToLower() != "image/jpg" &&
        //            ImageFile.ContentType.ToLower() != "image/jpeg" &&
        //            ImageFile.ContentType.ToLower() != "image/pjpeg" &&
        //            ImageFile.ContentType.ToLower() != "image/gif" &&
        //            ImageFile.ContentType.ToLower() != "image/x-png" &&
        //            ImageFile.ContentType.ToLower() != "image/png")
        //        {
        //            return Content("Please upload Image");
        //        }
        //        else
        //        {

        //            string _filename = Path.GetFileName(ImageFile.FileName);
        //            string _path = Path.Combine(Server.MapPath("~/ExamImage/"), _filename);
        //            if (!System.IO.File.Exists(_path))
        //            {
        //                ImageFile.SaveAs(_path);
        //                return Content("Upload Successed");
        //            }
        //            else
        //            {
        //                return Content("File already exist");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return Content("Empty File");
        //    }
        //}

        [HttpPost]
        public ActionResult Upload()
        {
            //HttpPostedFile ImageFile = context.Request.Files.Get(0);
            var ImageFile = Request.Files[0];

            //check Empty File
            if (ImageFile != null && ImageFile.ContentLength/1024/2014 < 2 )
            {
                //check image type
                if (ImageFile.ContentType.ToLower() != "image/jpg" &&
                    ImageFile.ContentType.ToLower() != "image/jpeg" &&
                    ImageFile.ContentType.ToLower() != "image/pjpeg" &&
                    ImageFile.ContentType.ToLower() != "image/gif" &&
                    ImageFile.ContentType.ToLower() != "image/x-png" &&
                    ImageFile.ContentType.ToLower() != "image/png")
                {
                    return Content("Please upload Image");
                }
                else
                {

                    string _filename = Path.GetFileName(ImageFile.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ExamImage/"), _filename);
                    if (!System.IO.File.Exists(_path))
                    {
                        ImageFile.SaveAs(_path);
                        return Content("Upload Successed");
                    }
                    else
                    {
                        return Content("File already exist");
                    }
                }
            }
            else
            {
                return Content("Empty File or Too Large File");
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
