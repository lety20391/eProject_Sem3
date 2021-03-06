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
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                var comments = db.Comments.OrderBy(item => item.num).Include(c => c.User);
                return View("Index", "_Layout", comments.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }


        }
        // GET: Comments/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") || User.IsInRole("Student"))
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
                return View("Details", "_Layout", comment);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }
        // GET: Comments/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick");
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,num,Detail,UserID,MainID,Status")] Comment comment)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                if (ModelState.IsValid)
                {
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick", comment.UserID);
                return View("Create", "_Layout", comment);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Comments/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
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
                return View("Edit", "_Layout", comment);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,num,Detail,UserID,MainID,Status")] Comment comment)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(comment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.UserID = new SelectList(db.Users, "IDUser", "UserNick", comment.UserID);
                return View("Edit", "_Layout", comment);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Comments/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
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
                return View("Delete", "_Layout", comment);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Student"))
            {
                Comment comment = db.Comments.Find(id);
                db.Comments.Remove(comment);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        //postcomment

            [HttpPost]
            public ActionResult postComment([Bind(Include = "Detail,MainID")] Comment newComment)
            {
            
                string UserID = db.Users.Where(item => item.UserNick.Equals(User.Identity.Name)).Select(item => item.IDUser).FirstOrDefault();
                newComment.UserID = UserID;
                newComment.Status = true;
                db.Comments.Add(newComment);
                db.SaveChanges();
                return Content("Success");
            }

        //postcomment

        //get list Comment in JSON format

        public ActionResult getCommentJSON(string id)
        {
            List<ShortComment> searchComment = db.Comments.Where(item => item.MainID.Equals(id) && item.Status == true).OrderBy(item => item.num).Select(item => new ShortComment()
            {
                Name = item.User.UserNick,
                Detail = item.Detail
            }).ToList();
            var result = new JsonResult()
            {
                Data = searchComment
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //get list Comment in JSON format




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
