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
        [Authorize(Roles = "Admin, Staff, Manager")]
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Class);
            return View("Index", "_Layout",students.ToList());
        }

        // GET: Students/Details/5
        [Authorize(Roles = "Admin, Staff, Manager")]
        public ActionResult Details(string id)
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
            return View("Details" , "_Layout",student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            return View("Create", "_Layout");
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create([Bind(Include = "StudentID,num,Name,Gender,DOB,Phone,Address,ClassID,Admission,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
            return View("Create", "_Layout",student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit(string id)
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
            return View("Edit", "_Layout",student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit([Bind(Include = "StudentID,num,Name,Gender,DOB,Phone,Address,ClassID,Admission,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
            return View("Edit", "_Layout",student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Delete(string id)
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
            return View("Delete" , "_Layout",student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
