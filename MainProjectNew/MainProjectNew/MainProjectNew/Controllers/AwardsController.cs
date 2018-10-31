using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainProjectNew.Models;

using System.Security.Principal;

namespace MainProjectNew.Controllers
{
    public class AwardsController : Controller
    {
        private ModelMain db = new ModelMain();
        // GET: Awards
        public ActionResult Index()
        {
              if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {               
                return View("Index", "_Layout", db.Awards.ToList());
            }
            else
            { 
                return RedirectToAction("Contact", "Home");
            }
        }
        
        // GET: Awards/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Award award = db.Awards.Find(id);
                if (award == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", award);
            }
            else

                return RedirectToAction("Contact", "Home");
      
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "Detail");
                return View("Create", "_Layout");
            }
            else

                return RedirectToAction("Contact", "Home");
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AwardID,num,PriceLevied,CompetitionID,Quantity")] Award award)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Awards.Add(award);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("Create", "_Layout", award);
            }
            else
                return RedirectToAction("Contact", "Home");
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Award award = db.Awards.Find(id);
                if (award == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "Detail", award.CompetitionID);
                return View("Edit", "_Layout", award);
            }
            else

                return RedirectToAction("Contact", "Home");
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AwardID,num,PriceLevied,CompetitionID,Quantity")] Award award)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(award).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CompetitionID = new SelectList(db.Competitions, "CompetitionID", "Detail", award.CompetitionID);
                return View("Edit", "_Layout", award);
            }
            else

                return RedirectToAction("Contact", "Home");



        }

        // GET: Awards/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Award award = db.Awards.Find(id);
                if (award == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", award);
            }
            else

                return RedirectToAction("Contact", "Home");

        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                Award award = db.Awards.Find(id);
                db.Awards.Remove(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else

                return RedirectToAction("Contact", "Home");
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
