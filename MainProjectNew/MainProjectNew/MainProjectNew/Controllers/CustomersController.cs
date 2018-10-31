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
    public class CustomersController : Controller
    {
        private ModelMain db = new ModelMain();

        // GET: Customers
        [Authorize(Roles = "Admin, Staff, Manager")]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff"))
            {
                var customers = db.Customers.Include(c => c.Exam).Include(c => c.Exhibition);
                return View("Index", "_Layout", customers.ToList());
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Staff") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View("Details", "_Layout", customer);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path");
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail");
                return View("Create", "_Layout");

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,num,Name,Gender,Phone,Address,IDExhibition,IDExam")] Customer customer)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") )
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path", customer.IDExam);
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", customer.IDExhibition);
                return View("Create", "_Layout", customer);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path", customer.IDExam);
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", customer.IDExhibition);
                return View("Edit", "_Layout", customer);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,num,Name,Gender,Phone,Address,IDExhibition,IDExam")] Customer customer)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") )
            {
                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path", customer.IDExam);
                ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", customer.IDExhibition);
                return View("Edit", "_Layout", customer);
            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff") )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", "_Layout", customer);

            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }

        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
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
