using PP_5.DAL;
using PP_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web.Helpers;
using System.Security.Policy;

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
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                string phonePattern = @"^(\+?\d{1,3}[-.\s]?(\(?\d{1,4}\)?)?[-.\s]?)?(\d{1,4}[-.\s]?){1,3}\d{1,4}$";
                if (!_shopContext.Customers.Any(y => y.Phone == customer.Phone) && !_shopContext.Customers.Any(z => z.Email == customer.Email))
                {
                    if(!string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Phone)) 
                    {
                        if (Regex.IsMatch(customer.Email, emailPattern) && Regex.IsMatch(customer.Phone, phonePattern))
                        {
                            customer.Password = SignInController.GetHashString(customer.Password);
                            _shopContext.Customers.Add(customer);
                            _shopContext.SaveChanges();
                            return RedirectToAction("SignIn", "SignIn");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Почта или телефон не подходит");
                            return View(customer);
                        }
                    }
                    ModelState.AddModelError("", "Заполните все данные");
                    return View(customer);
                }
                ModelState.AddModelError("", "Пользователь с такими данными уже существует.");
            }
            return View(customer);
        }
    }
}