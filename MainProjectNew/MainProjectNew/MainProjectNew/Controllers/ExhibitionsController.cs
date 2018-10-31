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
    public class ExhibitionsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Exhibitions
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") || User.IsInRole("Student"))
            {
                return View("Index", "_Layout", db.Exhibitions.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exhibitions/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") || User.IsInRole("Student"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Exhibition exhibition = db.Exhibitions.Find(id);
                if (exhibition == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", exhibition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exhibitions/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff")|| User.IsInRole("Student"))
            {
                return View("Create", "_Layout");
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exhibitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExhibitionID,num,Detail,Country,StartDate,EndDate,Condition,Quantity")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin") || User.IsInRole("Staff"))
                {
                    db.Exhibitions.Add(exhibition);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("Create", "_Layout", exhibition);

            }
            else
                {
                    return RedirectToAction("Contact", "Home");
                }
        }

        // GET: Exhibitions/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Exhibition exhibition = db.Exhibitions.Find(id);
                if (exhibition == null)
                {
                    return HttpNotFound();
                }
                return View("Edit", "_Layout", exhibition);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExhibitionID,num,Detail,Country,StartDate,EndDate,Condition,Quantity")] Exhibition exhibition)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(exhibition).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Edit", "_Layout", exhibition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Exhibitions/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Exhibition exhibition = db.Exhibitions.Find(id);
                if (exhibition == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", exhibition);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                Exhibition exhibition = db.Exhibitions.Find(id);
                db.Exhibitions.Remove(exhibition);
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
    }
}
