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
    public class Component_TypeController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Component_Type
        public ActionResult Index()
        {
            return View(db.ComponentTypes.ToList());
        }

        // GET: Component_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component_Type component_Type = db.ComponentTypes.Find(id);
            if (component_Type == null)
            {
                return HttpNotFound();
            }
            return View(component_Type);
        }

        // GET: Component_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Component_Type/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Component_TypeID,Name")] Component_Type component_Type)
        {
            if (ModelState.IsValid)
            {
                db.ComponentTypes.Add(component_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(component_Type);
        }

        // GET: Component_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component_Type component_Type = db.ComponentTypes.Find(id);
            if (component_Type == null)
            {
                return HttpNotFound();
            }
            return View(component_Type);
        }

        // POST: Component_Type/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Component_TypeID,Name")] Component_Type component_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(component_Type);
        }

        // GET: Component_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component_Type component_Type = db.ComponentTypes.Find(id);
            if (component_Type == null)
            {
                return HttpNotFound();
            }
            return View(component_Type);
        }

        // POST: Component_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component_Type component_Type = db.ComponentTypes.Find(id);
            db.ComponentTypes.Remove(component_Type);
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
