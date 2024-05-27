using PP_5.DAL;
using PP_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PP_5.Controllers
{
    public class SignInController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([Bind(Include = "Email,Password")] Customer customer)
        {
            var existingCustomer = db.Customers.FirstOrDefault(c => c.Email == customer.Email && c.Password == customer.Password);

            if (existingCustomer != null)
            {
                return RedirectToAction("LogIn", "SignIn");
            }

            return View();
        }
    }
}