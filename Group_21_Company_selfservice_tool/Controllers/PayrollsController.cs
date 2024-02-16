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
    public class PayrollsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Payrolls
        public ActionResult Index()
        {
            var payroll = db.Payroll.Include(p => p.Employee1);
            return View(payroll.ToList());
        }

        // GET: Payrolls/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = db.Payroll.Find(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // GET: Payrolls/Create
        public ActionResult Create()
        {
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Payrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Payroll_ID,Payroll_Type,employee")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                db.Payroll.Add(payroll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", payroll.employee);
            return View(payroll);
        }

        // GET: Payrolls/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = db.Payroll.Find(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", payroll.employee);
            return View(payroll);
        }

        // POST: Payrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Payroll_ID,Payroll_Type,employee")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", payroll.employee);
            return View(payroll);
        }

        // GET: Payrolls/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = db.Payroll.Find(id);
            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // POST: Payrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Payroll payroll = db.Payroll.Find(id);
            db.Payroll.Remove(payroll);
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
