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
            var customers = db.Customers.Include(c => c.Exam).Include(c => c.Exhibition);
            return View("Index", "_Layout",customers.ToList());
        }

        // GET: Customers/Details/5
        [Authorize(Roles = "Admin, Staff, Manager")]
        public ActionResult Details(string id)
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
            return View("Details", "_Layout",customer);
        }

        // GET: Customers/Create
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create()
        {
            ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path");
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail");
            return View("Create", "_Layout");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Create([Bind(Include = "CustomerID,num,Name,Gender,Phone,Address,IDExhibition,IDExam")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path", customer.IDExam);
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", customer.IDExhibition);
            return View("Create", "_Layout",customer);
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit(string id)
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
            return View("Edit", "_Layout",customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Edit([Bind(Include = "CustomerID,num,Name,Gender,Phone,Address,IDExhibition,IDExam")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDExam = new SelectList(db.Exams, "ExamID", "Path", customer.IDExam);
            ViewBag.IDExhibition = new SelectList(db.Exhibitions, "ExhibitionID", "Detail", customer.IDExhibition);
            return View("Edit", "_Layout",customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Delete(string id)
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
            return View("Delete", "_Layout",customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Staff")]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
