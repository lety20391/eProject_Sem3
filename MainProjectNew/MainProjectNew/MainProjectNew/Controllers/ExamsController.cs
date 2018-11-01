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
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") || User.IsInRole("Student"))
            {
                var exams = db.Exams.Include(e => e.Award).Include(e => e.Competition).Include(e => e.Exhibition).Include(e => e.Student);
                return View("Index", "_Layout", exams.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exams/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") || User.IsInRole("Student"))
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
                return View("Details", "_Layout", exam);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff")|| User.IsInRole("Student"))
            {
                ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID");
                ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail");
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail");
                ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name");
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ExamID,num,Path,Quotation,Story,IDStudent,IDCompetition,IDExhibition,Mark,IDAward,ChangeDescription,Status,MoneyReturn,Price,Improvement")] Exam exam)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff")  || User.IsInRole("Student"))
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
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exams/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff")|| User.IsInRole("Student"))
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
                return View("Edit", "_Layout", exam);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamID,num,Path,Quotation,Story,IDStudent,IDCompetition,IDExhibition,Mark,IDAward,ChangeDescription,Status,MoneyReturn,Price,Improvement")] Exam exam)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
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
                return View("Edit", "_Layout", exam);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff")|| User.IsInRole("Student"))
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
                return View("Delete", "_Layout", exam);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") )
            {
                Exam exam = db.Exams.Find(id);
                db.Exams.Remove(exam);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

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
                        return Content("Image already exist");
                    }
                }
            }
            else
            {
                return Content("Empty File or Too Large File");
            }
        }

        //danh cho student Submit

        public ActionResult studentSubmit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                
                List<Competition> searchComp = db.Competitions.Where(item => item.CompetitionID.Equals(id)).ToList();

                string studID = db.Users.Where(item => item.UserNick.Equals(User.Identity.Name)).Select(item => item.Real_ID).First();
                List<Student> searchStud = db.Students.Where(item => item.StudentID.Equals(studID)).ToList();

                System.Diagnostics.Debug.WriteLine(studID);
                System.Diagnostics.Debug.WriteLine(User.Identity.Name);

                ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID");
                ViewBag.IDCompetition = new SelectList(searchComp, "CompetitionID", "CompetitionID");
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "ExhibitionID");
                ViewBag.IDStudent = new SelectList(searchStud, "StudentID", "StudentID");
                return View("studentSubmit", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }


        [HttpPost]
        public ActionResult studentSubmit([Bind(Include = "ExamID,num,Path,Quotation,Story,IDStudent,IDCompetition,IDExhibition,Mark,IDAward,ChangeDescription,Status,MoneyReturn,Price,Improvement")] Exam exam)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                if (ModelState.IsValid)
                {
                    db.Exams.Add(exam);
                    db.SaveChanges();

                    //goi submit controller de add them data vao
                    //var submitController = new SubmitsController();
                    //submitController.ControllerContext = ControllerContext;

                    //tao submit moi de luu IDExam va IDCompetition co lien quan
                    //lay examID vua tao tu Database theo Path vi Path mac dinh la luu khong trung nhau
                    string examID = db.Exams.Where(item => item.Path.Equals(exam.Path)).Select(item => item.ExamID).First();

                    Submit newSubmit = new Submit();
                    newSubmit.Entity1ID = examID;
                    newSubmit.Entity2ID = exam.IDCompetition;
                    newSubmit.Type = "Exam-Competition";
                    db.Submits.Add(newSubmit);
                    db.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("--------------------------------");
                    System.Diagnostics.Debug.WriteLine(examID);
                    System.Diagnostics.Debug.WriteLine(exam.IDCompetition);
                    System.Diagnostics.Debug.WriteLine("--------------------------------");

                    
                    return Content("Create Succesfully");
                    
                }

                ViewBag.IDAward = new SelectList(db.Awards, "AwardID", "CompetitionID", exam.IDAward);
                ViewBag.IDCompetition = new SelectList(db.Competitions, "CompetitionID", "Detail", exam.IDCompetition);
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", exam.IDExhibition);
                ViewBag.IDStudent = new SelectList(db.Students, "StudentID", "Name", exam.IDStudent);
                return Content("Create Failed");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        //danh cho student Submit

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
