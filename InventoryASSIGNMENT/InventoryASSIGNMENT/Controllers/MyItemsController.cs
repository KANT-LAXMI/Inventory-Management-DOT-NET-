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
    public class MyItemsController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: MyItems
        public ActionResult Index()
        {
            var myItems = db.MyItems.Include(m => m.MyCategory).Include(m => m.MyUser);
            return View(myItems.ToList());
        }

        // GET: MyItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyItem myItem = db.MyItems.Find(id);
            if (myItem == null)
            {
                return HttpNotFound();
            }
            return View(myItem);
        }
        public ActionResult Report() 
        {
            var myItems = db.MyItems.Include(m => m.MyCategory).Include(m => m.MyUser);
            return View(myItems.ToList());
            
        }



        // GET: MyItems/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.MyCategories, "cat_id", "cat_name");
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname");
            return View();
        }

        // POST: MyItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_item,itname,qty,sold_qty,cost_price,sales_price,manufacturer,address,tel,cat_id,user_id")] MyItem myItem)
        {
            if (ModelState.IsValid)
            {
                db.MyItems.Add(myItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.MyCategories, "cat_id", "cat_name", myItem.cat_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myItem.user_id);
            return View(myItem);
        }

        // GET: MyItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyItem myItem = db.MyItems.Find(id);
            if (myItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.MyCategories, "cat_id", "cat_name", myItem.cat_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myItem.user_id);
            return View(myItem);
        }

        // POST: MyItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_item,itname,qty,sold_qty,cost_price,sales_price,manufacturer,address,tel,cat_id,user_id")] MyItem myItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.MyCategories, "cat_id", "cat_name", myItem.cat_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myItem.user_id);
            return View(myItem);
        }

        // GET: MyItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyItem myItem = db.MyItems.Find(id);
            if (myItem == null)
            {
                return HttpNotFound();
            }
            return View(myItem);
        }

        // POST: MyItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyItem myItem = db.MyItems.Find(id);
            db.MyItems.Remove(myItem);
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
