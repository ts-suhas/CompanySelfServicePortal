using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group_21_Company_selfservice_tool.Models;

namespace Group_21_Company_selfservice_tool.Controllers
{
    public class Personal_ProfileController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Personal_Profile
        public ActionResult Index()
        {
            var personal_Profile = db.Personal_Profile.Include(p => p.User1);
            return View(personal_Profile.ToList());
        }

        // GET: Personal_Profile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Profile personal_Profile = db.Personal_Profile.Find(id);
            if (personal_Profile == null)
            {
                return HttpNotFound();
            }
            return View(personal_Profile);
        }

        // GET: Personal_Profile/Create
        public ActionResult Create()
        {
            ViewBag.user = new SelectList(db.User, "User_ID", "Username");
            return View();
        }

        // POST: Personal_Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Profile_ID,Gender,SSN,Personal_gmail,Address,Phone,user")] Personal_Profile personal_Profile)
        {
            if (ModelState.IsValid)
            {
                db.Personal_Profile.Add(personal_Profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user = new SelectList(db.User, "User_ID", "Username", personal_Profile.user);
            return View(personal_Profile);
        }

        // GET: Personal_Profile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Profile personal_Profile = db.Personal_Profile.Find(id);
            if (personal_Profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.user = new SelectList(db.User, "User_ID", "Username", personal_Profile.user);
            return View(personal_Profile);
        }

        // POST: Personal_Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile_ID,Gender,SSN,Personal_gmail,Address,Phone,user")] Personal_Profile personal_Profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user = new SelectList(db.User, "User_ID", "Username", personal_Profile.user);
            return View(personal_Profile);
        }

        // GET: Personal_Profile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Profile personal_Profile = db.Personal_Profile.Find(id);
            if (personal_Profile == null)
            {
                return HttpNotFound();
            }
            return View(personal_Profile);
        }

        // POST: Personal_Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Personal_Profile personal_Profile = db.Personal_Profile.Find(id);
            db.Personal_Profile.Remove(personal_Profile);
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
