using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainProjectNew.Models;

namespace MainProjectNew.Controllers
{
    public class CompetitionsController : Controller
    {
        private ModelMain db = new ModelMain();
        // GET: Competitions
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") )
            {
                var competitions = db.Competitions.Include(c => c.Award);
                return View("Index", "_Layout", competitions.ToList());

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }
        // GET: Competitions/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Competition competition = db.Competitions.Find(id);
                if (competition == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", competition);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

            
        }

        // GET: Competitions/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin")|| User.IsInRole("Staff") )
            {
                ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID");
                return View("Create", "_Layout");
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }


        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionID,num,Detail,StartDate,EndDate,Condition,AwardID")] Competition competition)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Competitions.Add(competition);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID", competition.AwardID);
                return View("Create", "_Layout", competition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Competitions/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Competition competition = db.Competitions.Find(id);
                if (competition == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID", competition.AwardID);
                return View("Edit", "_Layout", competition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetitionID,num,Detail,StartDate,EndDate,Condition,AwardID")] Competition competition)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(competition).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID", competition.AwardID);
                return View("Edit", "_Layout", competition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Competitions/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Competition competition = db.Competitions.Find(id);
                if (competition == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", competition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                Competition competition = db.Competitions.Find(id);
                db.Competitions.Remove(competition);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
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

        public ActionResult forStudent()
        {
            var competitions = db.Competitions.Include(c => c.Award);
            return View("forStudent", "_Layout", competitions.ToList());
        }

        public ActionResult forStaff()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager"))
            {
                var competitions = db.Competitions.Include(c => c.Award);
                return View("forStaff", "_Layout", competitions.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }
    }
}
