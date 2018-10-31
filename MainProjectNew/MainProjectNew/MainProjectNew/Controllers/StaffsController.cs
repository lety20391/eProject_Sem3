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
    public class StaffsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Staffs
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager"))
            {
                var staffs = db.Staffs.Include(s => s.Class);
                return View("Index", "_Layout", staffs.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Staffs/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Staff staff = db.Staffs.Find(id);
                if (staff == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", staff);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {

                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,num,Name,Gender,DOB,Phone,Address,ClassID,Subject,Status")] Staff staff)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", staff.ClassID);
                return View("Create", "_Layout", staff);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Staff staff = db.Staffs.Find(id);
                if (staff == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", staff.ClassID);
                return View("Edit", "_Layout", staff);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,num,Name,Gender,DOB,Phone,Address,ClassID,Subject,Status")] Staff staff)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(staff).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", staff.ClassID);
                return View("Edit", "_Layout", staff);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Staff staff = db.Staffs.Find(id);
                if (staff == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", staff);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin"))
            {
                Staff staff = db.Staffs.Find(id);
                db.Staffs.Remove(staff);
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
