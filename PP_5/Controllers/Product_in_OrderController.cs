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
    public class Product_in_OrderController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Product_in_Order
        public ActionResult Index()
        {
            var product_in_Orders = db.Product_in_Orders.Include(p => p.Order).Include(p => p.Product);
            return View(product_in_Orders.ToList());
        }

        // GET: Product_in_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_in_Order product_in_Order = db.Product_in_Orders.Find(id);
            if (product_in_Order == null)
            {
                return HttpNotFound();
            }
            return View(product_in_Order);
        }

        // GET: Product_in_Order/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        // POST: Product_in_Order/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_in_OrderID,ProductID,OrderID,Count")] Product_in_Order product_in_Order)
        {
            if (ModelState.IsValid)
            {
                db.Product_in_Orders.Add(product_in_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", product_in_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", product_in_Order.ProductID);
            return View(product_in_Order);
        }

        // GET: Product_in_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_in_Order product_in_Order = db.Product_in_Orders.Find(id);
            if (product_in_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", product_in_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", product_in_Order.ProductID);
            return View(product_in_Order);
        }

        // POST: Product_in_Order/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_in_OrderID,ProductID,OrderID,Count")] Product_in_Order product_in_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_in_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", product_in_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", product_in_Order.ProductID);
            return View(product_in_Order);
        }

        // GET: Product_in_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_in_Order product_in_Order = db.Product_in_Orders.Find(id);
            if (product_in_Order == null)
            {
                return HttpNotFound();
            }
            return View(product_in_Order);
        }

        // POST: Product_in_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_in_Order product_in_Order = db.Product_in_Orders.Find(id);
            db.Product_in_Orders.Remove(product_in_Order);
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
