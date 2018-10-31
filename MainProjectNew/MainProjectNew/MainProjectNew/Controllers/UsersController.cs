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
    public class UsersController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Users
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager"))
            {
                return View("Index", "_Layout", db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") || User.IsInRole("Manager") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", user);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUser,num,UserNick,UserPass,Real_ID,Role,Status")] User user)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("Create", "_Layout", user);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View("Edit", "_Layout", user);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUser,num,UserNick,UserPass,Real_ID,Role,Status")] User user)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Edit", "_Layout", user);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", user);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin"))
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
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
