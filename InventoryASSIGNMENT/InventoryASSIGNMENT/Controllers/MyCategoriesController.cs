using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryASSIGNMENT.Models;

namespace InventoryASSIGNMENT.Controllers
{
    public class MyCategoriesController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: MyCategories
        public ActionResult Index()
        {
            return View(db.MyCategories.ToList());
        }

        // GET: MyCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCategory myCategory = db.MyCategories.Find(id);
            if (myCategory == null)
            {
                return HttpNotFound();
            }
            return View(myCategory);
        }

        // GET: MyCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_name,cat_comment,cat_date")] MyCategory myCategory)
        {
            if (ModelState.IsValid)
            {
                db.MyCategories.Add(myCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myCategory);
        }

        // GET: MyCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCategory myCategory = db.MyCategories.Find(id);
            if (myCategory == null)
            {
                return HttpNotFound();
            }
            return View(myCategory);
        }

        // POST: MyCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_name,cat_comment,cat_date")] MyCategory myCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myCategory);
        }

        // GET: MyCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCategory myCategory = db.MyCategories.Find(id);
            if (myCategory == null)
            {
                return HttpNotFound();
            }
            return View(myCategory);
        }

        // POST: MyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyCategory myCategory = db.MyCategories.Find(id);
            db.MyCategories.Remove(myCategory);
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
