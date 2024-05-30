using PP_5.DAL;
using PP_5.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace PP_5.Controllers
{
    public class ProfileController : Controller
    {
        private ShopContext _shopContext = new ShopContext();
        // GET: Profile
        [HttpGet]
        public ActionResult Profile()
        {
            var customer = (Customer)Session["CurrentCustomer"];
            if (customer == null)
            {
                return View("~/Views/SignIn/SignIn.cshtml");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult AdminProfile()
        {
            var customer = (Customer)Session["CurrentCustomer"];
            if (customer == null)
            {
                return View("~/Views/SignIn/SignIn.cshtml");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Edit() 
        {
            var customer = (Customer)Session["CurrentCustomer"];
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customeredit)
        {
            if (ModelState.IsValid)
            {
                var customer = (Customer)Session["CurrentCustomer"];
                int customerId = customer.CustomerID;
                Customer customersave = _shopContext.Customers.Find(customerId);
                if (customer != null)
                {
                    customersave.FIO = customeredit.FIO;
                    customersave.Phone = customeredit.Phone;
                    customersave.Password = customeredit.Password;
                    customersave.Email = customer.Email;
                    _shopContext.SaveChanges();
                    Session["CurrentCustomer"] = customersave;
                    if (customersave.root == UserRole.ADMIN)
                    {
                        return RedirectToAction("AdminProfile");
                    }
                    else
                    {
                        return RedirectToAction("Profile");
                    }
                }
            }
            return View(customeredit);
        }
    }
}