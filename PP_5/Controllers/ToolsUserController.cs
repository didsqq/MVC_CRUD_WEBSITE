using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private Order order;
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
        public ActionResult Orders()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }
        public ActionResult Delete(int? id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }
        public ActionResult Order(int? id)
        {
            customer = (Customer)Session["CurrentCustomer"];
            MailAddress from = new MailAddress("didsqq@yandex.ru", "Adel");
            Order order = db.Orders.Find(id);
            try
            {
                MailAddress to = new MailAddress(customer.Email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Заказ оформлен";
                m.Body = $"Поздравляю, ваш заказ на сумму {order.Total_Amount} оформлен\n\n\nВремя оформления:{order.Date}";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.Credentials = new NetworkCredential("didsqq@yandex.ru", "lhybtwljdlunlgjk");
                smtp.EnableSsl = true;
                smtp.Send(m);
                order.Status = "Оформлен";
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
            }
            return RedirectToAction("Orders");
        }
        [HttpPost]
        public ActionResult Buy(int? id, int quantity)
        {
            customer = (Customer)Session["CurrentCustomer"];
            Product product = db.Products.Find(id);

            if (product != null && customer != null && quantity > 0 && quantity <= product.Count)
            {
                order = new Order
                {
                    ProductID = product.ProductID,
                    CustomerID = customer.CustomerID,
                    Total_Amount = product.Price * quantity,
                    Status = "Ожидание",
                    Product_Count = quantity,
                    Date = DateTime.Now
                };

                product.Count -= quantity;
                db.Orders.Add(order);
                db.SaveChanges();
            }

            return RedirectToAction("Products");
        }
    }
}