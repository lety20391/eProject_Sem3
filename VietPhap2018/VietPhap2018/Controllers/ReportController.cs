using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VietPhap2018.Models;

namespace VietPhap2018.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        private AppDB dbReport = new AppDB();
        
        //[Authorize(Users ="FOSM")]
        public ActionResult Index()
        {
            //De danh tim hieu phan nay sau

            //HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            //string cookiePath = ticket.CookiePath;
            //DateTime expiration = ticket.Expiration;
            //bool expired = ticket.Expired;
            //bool isPersistent = ticket.IsPersistent;
            //DateTime issueDate = ticket.IssueDate;
            //string name = ticket.Name;
            //string userData = ticket.UserData;
            //int version = ticket.Version;

            //De danh tim hieu phan nay sau

            bool isLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return View(dbReport.tbReport.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            bool isLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return View(dbReport.tbReport.Find(id));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Report editedReport)
        {
            if (ModelState.IsValid)
            {
                Report currentReport = dbReport.tbReport.Find(editedReport.IDgenerate);
                if ( currentReport != null)
                {
                    currentReport.UserName = editedReport.UserName;
                    currentReport.DetailReport = editedReport.DetailReport;
                    currentReport.Hall = editedReport.Hall;
                    currentReport.Status = editedReport.Status;
                    currentReport.TargetTime = editedReport.TargetTime;
                    currentReport.Start = editedReport.Start;
                    currentReport.End = editedReport.End;
                    currentReport.Check = editedReport.Check;
                    dbReport.SaveChanges();
                    return RedirectToAction("Index", dbReport.tbReport.ToList());
                }
            }
            ModelState.AddModelError("", "Lỗi rồi anh em");
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            bool isLoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(Report newReport)
        {
            if (ModelState.IsValid)
            {
                dbReport.tbReport.Add(newReport);
                dbReport.SaveChanges();
                return View("Index", dbReport.tbReport.ToList());
            }
            ModelState.AddModelError("", "Lỗi rồi anh em");
            return View();
        }
    }
}