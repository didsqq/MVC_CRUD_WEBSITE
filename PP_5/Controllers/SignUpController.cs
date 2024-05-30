using PP_5.DAL;
using PP_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP_5.Controllers
{
    public class SignUpController : Controller
    {
        private ShopContext _shopContext = new ShopContext();
        // GET: SignUp

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (!_shopContext.Customers.Any(y => y.Phone == customer.Phone) &&
                    !_shopContext.Customers.Any(z => z.Email == customer.Email))
                {
                    customer.Password = SignInController.GetHashString(customer.Password);
                    _shopContext.Customers.Add(customer);
                    _shopContext.SaveChanges();
                    return RedirectToAction("SignIn", "SignIn");
                }
                ModelState.AddModelError("", "Пользователь с такими данными уже существует.");
            }
            return View(customer);
        }
    }
}