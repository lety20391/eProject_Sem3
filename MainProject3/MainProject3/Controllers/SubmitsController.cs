using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainProject3.Models;

namespace MainProject3.Controllers
{
    public class SubmitsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Submits
        public ActionResult Index()
        {
            return View("Index", "_Layout", db.Submits.ToList());
        }

        // GET: Submits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                return HttpNotFound();
            }
            return View("Details", "_Layout", submit);
        }

        // GET: Submits/Create
        public ActionResult Create()
        {
            return View("Create", "_Layout");
        }

        // POST: Submits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSubmit,ID,Entity1ID,Entity2ID,Type")] Submit submit)
        {
            if (ModelState.IsValid)
            {
                db.Submits.Add(submit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", "_Layout", submit);
        }

        // GET: Submits/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                return HttpNotFound();
            }
            return View("Edit", "_Layout", submit);
        }

        // POST: Submits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSubmit,ID,Entity1ID,Entity2ID,Type")] Submit submit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(submit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", "_Layout", submit);
        }

        // GET: Submits/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                return HttpNotFound();
            }
            return View("Delete", "_Layout", submit);
        }

        // POST: Submits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Submit submit = db.Submits.Find(id);
            db.Submits.Remove(submit);
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
