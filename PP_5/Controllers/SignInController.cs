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
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer existingCustomer = new Customer();
                try
                {
                    customer.Password = GetHashString(customer.Password);
                    existingCustomer = db.Customers.FirstOrDefault(c => c.Email == customer.Email && c.Password == customer.Password);
                }
                catch ( ArgumentNullException ex )
                {
                    ModelState.AddModelError("", $"Пользователь не найден: {ex.Message}");
                }
                if (existingCustomer != null)
                {
                    Session["CurrentCustomer"] = existingCustomer;
                    if (existingCustomer.root == UserRole.ADMIN)
                    {
                        return RedirectToAction("AdminProfile", "Profile");
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Profile");
                    }
                }
                ModelState.AddModelError("", "Ошибка ввода логина или пароля");
            }
            return View(customer);
        }
        public static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}