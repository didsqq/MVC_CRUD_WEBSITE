using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PP_5.DAL;
using PP_5.Models;

namespace PP_5.Controllers
{
    public class ToolsUserController : Controller
    {
        private ShopContext db = new ShopContext();
        private Customer customer;
        // GET: ToolsUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            var products = db.Products.Include(p => p.Provider);
            return View(products.ToList());
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "SignIn");
        }
        public ActionResult Profile()
        {
            return RedirectToAction("Profile", "Profile");
        }
        public ActionResult AdminProfile()
        {
            return RedirectToAction("AdminProfile", "Profile");
        }

        public ActionResult Buy(int? id)
        {
            customer = (Customer)Session["CurrentCustomer"];
            Product product = db.Products.Find(id);
            if (product != null)
            {
                product.Count--;
                db.SaveChanges();
            }
            return RedirectToAction("Products");
        }
    }
}