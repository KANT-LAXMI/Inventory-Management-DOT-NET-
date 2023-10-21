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
    public class MyOrdersController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: MyOrders
        public ActionResult Index()
        {
            var myOrders = db.MyOrders.Include(m => m.myCustomer).Include(m => m.MyUser);
            return View(myOrders.ToList());
        }

        // GET: MyOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyOrder myOrder = db.MyOrders.Find(id);
            if (myOrder == null)
            {
                return HttpNotFound();
            }
            return View(myOrder);
        }

        // GET: MyOrders/Create
        public ActionResult Create()
        {
            ViewBag.cus_id = new SelectList(db.myCustomers, "cus_id", "fname");
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname");
            return View();
        }

        // POST: MyOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,order_name,qty,order_date,due_date,status,user_id,cus_id")] MyOrder myOrder)
        {
            if (ModelState.IsValid)
            {
                db.MyOrders.Add(myOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cus_id = new SelectList(db.myCustomers, "cus_id", "fname", myOrder.cus_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myOrder.user_id);
            return View(myOrder);
        }

        // GET: MyOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyOrder myOrder = db.MyOrders.Find(id);
            if (myOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.cus_id = new SelectList(db.myCustomers, "cus_id", "fname", myOrder.cus_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myOrder.user_id);
            return View(myOrder);
        }

        // POST: MyOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,order_name,qty,order_date,due_date,status,user_id,cus_id")] MyOrder myOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cus_id = new SelectList(db.myCustomers, "cus_id", "fname", myOrder.cus_id);
            ViewBag.user_id = new SelectList(db.MyUsers, "user_id", "fname", myOrder.user_id);
            return View(myOrder);
        }

        // GET: MyOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyOrder myOrder = db.MyOrders.Find(id);
            if (myOrder == null)
            {
                return HttpNotFound();
            }
            return View(myOrder);
        }

        // POST: MyOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyOrder myOrder = db.MyOrders.Find(id);
            db.MyOrders.Remove(myOrder);
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
