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
    public class TimesheetsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Timesheets
        public ActionResult Index()
        {
            var timesheet = db.Timesheet.Include(t => t.Employee1).Include(t => t.Leaves).Include(t => t.Payroll1);
            return View(timesheet.ToList());
        }

        // GET: Timesheets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheet.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // GET: Timesheets/Create
        public ActionResult Create()
        {
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            ViewBag.leave = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type");
            ViewBag.payroll = new SelectList(db.Payroll, "Payroll_ID", "Payroll_Type");
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Timesheet_ID,Total_Working_Hours_Per_Month,Week_Number,employee,leave,payroll")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                db.Timesheet.Add(timesheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", timesheet.employee);
            ViewBag.leave = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", timesheet.leave);
            ViewBag.payroll = new SelectList(db.Payroll, "Payroll_ID", "Payroll_Type", timesheet.payroll);
            return View(timesheet);
        }

        // GET: Timesheets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheet.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", timesheet.employee);
            ViewBag.leave = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", timesheet.leave);
            ViewBag.payroll = new SelectList(db.Payroll, "Payroll_ID", "Payroll_Type", timesheet.payroll);
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Timesheet_ID,Total_Working_Hours_Per_Month,Week_Number,employee,leave,payroll")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", timesheet.employee);
            ViewBag.leave = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", timesheet.leave);
            ViewBag.payroll = new SelectList(db.Payroll, "Payroll_ID", "Payroll_Type", timesheet.payroll);
            return View(timesheet);
        }

        // GET: Timesheets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheet.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Timesheet timesheet = db.Timesheet.Find(id);
            db.Timesheet.Remove(timesheet);
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
