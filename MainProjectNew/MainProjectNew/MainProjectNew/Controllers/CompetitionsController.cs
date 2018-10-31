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
        [Authorize(Roles = "Admin, Staff, Manager")]
        // GET: Competitions
        public ActionResult Index()
        {
            var competitions = db.Competitions.Include(c => c.Award);
            return View("Index", "_Layout",competitions.ToList());
        }
        [Authorize(Roles = "Admin, Staff, Manager")]
        // GET: Competitions/Details/5
        public ActionResult Details(string id)
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
            return View("Details", "_Layout",competition);
        }

        // GET: Competitions/Create
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create()
        {
            ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID");
            return View("Create", "_Layout");
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create([Bind(Include = "CompetitionID,num,Detail,StartDate,EndDate,Condition,AwardID")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID", competition.AwardID);
            return View("Create", "_Layout",competition);
        }

        // GET: Competitions/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit(string id)
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
            return View("Edit", "_Layout",competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit([Bind(Include = "CompetitionID,num,Detail,StartDate,EndDate,Condition,AwardID")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AwardID = new SelectList(db.Awards, "AwardID", "CompetitionID", competition.AwardID);
            return View("Edit", "_Layout",competition);
        }

        // GET: Competitions/Delete/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Delete(string id)
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
            return View("Delete", "_Layout",competition);
        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult DeleteConfirmed(string id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
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
