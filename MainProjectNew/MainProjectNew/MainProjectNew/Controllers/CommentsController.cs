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
    public class CommentsController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Comments
        [Authorize(Roles = "Admin, Staff, Manager,Student")]
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.User);
            return View("Index", "_Layout", comments.ToList());
        }
        [Authorize(Roles = "Admin, Staff, Manager,Student")]
        // GET: Comments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View("Details", "_Layout",comment);
        }
        [Authorize(Roles = "Admin, Staff, Student")]
        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick");
            return View("Create", "_Layout");
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult Create([Bind(Include = "CommentID,num,Detail,UserID,MainID,Status")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick", comment.UserID);
            return View("Create", "_Layout",comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick", comment.UserID);
            return View("Edit", "_Layout",comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult Edit([Bind(Include = "CommentID,num,Detail,UserID,MainID,Status")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick", comment.UserID);
            return View("Edit", "_Layout",comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View("Delete", "_Layout",comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff, Student")]
        public ActionResult DeleteConfirmed(string id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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