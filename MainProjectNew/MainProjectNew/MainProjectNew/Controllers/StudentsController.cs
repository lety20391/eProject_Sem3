﻿using System;
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
    public class StudentsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Students
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") )
            {
                var students = db.Students.Include(s => s.Class);
                return View("Index", "_Layout", students.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", student);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Students/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,num,Name,Gender,DOB,Phone,Address,ClassID,Admission,Status")] Student student)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
                return View("Create", "_Layout", student);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
                return View("Edit", "_Layout", student);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,num,Name,Gender,DOB,Phone,Address,ClassID,Admission,Status")] Student student)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
                return View("Edit", "_Layout", student);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", student);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
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
