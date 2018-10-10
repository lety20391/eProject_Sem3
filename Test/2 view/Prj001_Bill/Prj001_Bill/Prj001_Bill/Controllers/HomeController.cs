using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj001_Bill.Models;

namespace Prj001_Bill.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ModelDatabase db = new ModelDatabase();
        public ActionResult Index()
        {
            return View("LenDon");
        }

        [HttpPost]
        public ActionResult Index(Bill newBill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tbBill.Add(newBill);
                    db.SaveChanges();
                    ModelState.AddModelError("", "Thành công");
                    return View("LenDon", new Bill());
                }
                ModelState.AddModelError("", "Thử lại lần nữa anh em ơi " );
                return View("LenDon");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Lỗi mất rồi: " + e.Message);
                return View("LenDon");
            }
        }

        public ActionResult getProduct()
        {
            List<Product> searchProduct = db.tbProduct.ToList();
            var result = new JsonResult()
            {
                Data = searchProduct
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult getProductList()
        {
            return PartialView("getProductList", db.tbProduct.ToList());
        }
    }
}