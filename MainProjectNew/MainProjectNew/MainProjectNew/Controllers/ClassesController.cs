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
    public class ClassesController : Controller
    {
        private ModelMain db = new ModelMain();
        // GET: Classes
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") )
            {
                return View("Index", "_Layout", db.Classes.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }
        // GET: Classes/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Class @class = db.Classes.Find(id);
                if (@class == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", @class);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }
        // GET: Classes/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin")|| User.IsInRole("Staff"))
            {
                return View("Create", "_Layout");
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,num,ClassName")] Class @class)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Classes.Add(@class);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("Create", "_Layout", @class);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }
        // GET: Classes/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Class @class = db.Classes.Find(id);
                if (@class == null)
                {
                    return HttpNotFound();
                }
                return View("Edit", "_Layout", @class);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,num,ClassName")] Class @class)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {

                if (ModelState.IsValid)
                {
                    db.Entry(@class).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Edit", "_Layout", @class);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Classes/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Class @class = db.Classes.Find(id);
                if (@class == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", @class);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }


        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {

                Class @class = db.Classes.Find(id);
                db.Classes.Remove(@class);
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
