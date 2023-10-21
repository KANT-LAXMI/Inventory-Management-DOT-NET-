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
    public class MyUsersController : Controller
    {
        private C3IT_DOTNET_TESTEntities db = new C3IT_DOTNET_TESTEntities();

        // GET: MyUsers
        public ActionResult Index()
        {
            return View(db.MyUsers.ToList());
        }

        // GET: MyUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // GET: MyUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,fname,lname,Attname,dob,gender,Email,tel,address,user_level,Password,udate")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.MyUsers.Add(myUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myUser);
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: MyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] MyUser myUser)
        {
            MyUser myUser1 = db.MyUsers.FirstOrDefault(u => u.Email == myUser.Email && u.Password == myUser.Password);
            if (myUser1 != null && myUser1.user_level == "admin")
            {
                return View("welcome");
            }
            else if (myUser1 != null && myUser1.user_level == "salesperson")
            {
                return View("salesWelcome");
            }

            return View(myUser);
        }


        public ActionResult logout()
        {
            return View();
        }

        // POST: MyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        
        // GET: MyUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,fname,lname,Attname,dob,gender,Email,tel,address,user_level,Password,udate")] MyUser myUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myUser);
        }

        // GET: MyUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyUser myUser = db.MyUsers.Find(id);
            if (myUser == null)
            {
                return HttpNotFound();
            }
            return View(myUser);
        }

        // POST: MyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyUser myUser = db.MyUsers.Find(id);
            db.MyUsers.Remove(myUser);
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
