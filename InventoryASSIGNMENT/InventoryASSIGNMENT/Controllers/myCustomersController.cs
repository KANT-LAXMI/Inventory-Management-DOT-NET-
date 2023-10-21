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
    public class myCustomersController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: myCustomers
        public ActionResult Index()
        {
            return View(db.myCustomers.ToList());
        }

        // GET: myCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myCustomer myCustomer = db.myCustomers.Find(id);
            if (myCustomer == null)
            {
                return HttpNotFound();
            }
            return View(myCustomer);
        }

        // GET: myCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: myCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cus_id,fname,lname,gender,email,tel,address,cdate")] myCustomer myCustomer)
        {
            if (ModelState.IsValid)
            {
                db.myCustomers.Add(myCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myCustomer);
        }

        // GET: myCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myCustomer myCustomer = db.myCustomers.Find(id);
            if (myCustomer == null)
            {
                return HttpNotFound();
            }
            return View(myCustomer);
        }

        // POST: myCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cus_id,fname,lname,gender,email,tel,address,cdate")] myCustomer myCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myCustomer);
        }

        // GET: myCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myCustomer myCustomer = db.myCustomers.Find(id);
            if (myCustomer == null)
            {
                return HttpNotFound();
            }
            return View(myCustomer);
        }

        // POST: myCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            myCustomer myCustomer = db.myCustomers.Find(id);
            db.myCustomers.Remove(myCustomer);
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

        public ActionResult LongTermCustomers()
        {
            DateTime fiveYearsAgo = DateTime.Today.AddYears(-5);



            var longTermCustomers = db.myCustomers
                .Where(customer => customer.cdate <= fiveYearsAgo)
                .ToList();



            return View(longTermCustomers);
        }




    }
}
