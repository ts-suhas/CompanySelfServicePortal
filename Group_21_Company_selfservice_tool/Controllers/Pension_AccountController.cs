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
    public class Pension_AccountController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Pension_Account
        public ActionResult Index()
        {
            var pension_Account = db.Pension_Account.Include(p => p.Employee1);
            return View(pension_Account.ToList());
        }

        // GET: Pension_Account/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pension_Account pension_Account = db.Pension_Account.Find(id);
            if (pension_Account == null)
            {
                return HttpNotFound();
            }
            return View(pension_Account);
        }

        // GET: Pension_Account/Create
        public ActionResult Create()
        {
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Pension_Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pension_Account_ID,Holder_Name,Nominees,employee")] Pension_Account pension_Account)
        {
            if (ModelState.IsValid)
            {
                db.Pension_Account.Add(pension_Account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", pension_Account.employee);
            return View(pension_Account);
        }

        // GET: Pension_Account/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pension_Account pension_Account = db.Pension_Account.Find(id);
            if (pension_Account == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", pension_Account.employee);
            return View(pension_Account);
        }

        // POST: Pension_Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pension_Account_ID,Holder_Name,Nominees,employee")] Pension_Account pension_Account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pension_Account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", pension_Account.employee);
            return View(pension_Account);
        }

        // GET: Pension_Account/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pension_Account pension_Account = db.Pension_Account.Find(id);
            if (pension_Account == null)
            {
                return HttpNotFound();
            }
            return View(pension_Account);
        }

        // POST: Pension_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pension_Account pension_Account = db.Pension_Account.Find(id);
            db.Pension_Account.Remove(pension_Account);
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
