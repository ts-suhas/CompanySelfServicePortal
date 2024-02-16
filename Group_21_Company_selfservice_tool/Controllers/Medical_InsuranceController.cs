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
    public class Medical_InsuranceController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Medical_Insurance
        public ActionResult Index()
        {
            var medical_Insurance = db.Medical_Insurance.Include(m => m.Employee1);
            return View(medical_Insurance.ToList());
        }

        // GET: Medical_Insurance/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Insurance medical_Insurance = db.Medical_Insurance.Find(id);
            if (medical_Insurance == null)
            {
                return HttpNotFound();
            }
            return View(medical_Insurance);
        }

        // GET: Medical_Insurance/Create
        public ActionResult Create()
        {
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Medical_Insurance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Insurance_ID,Insurance_Name,Insurance_Type,Coverage_Limit,Employee")] Medical_Insurance medical_Insurance)
        {
            if (ModelState.IsValid)
            {
                db.Medical_Insurance.Add(medical_Insurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", medical_Insurance.Employee);
            return View(medical_Insurance);
        }

        // GET: Medical_Insurance/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Insurance medical_Insurance = db.Medical_Insurance.Find(id);
            if (medical_Insurance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", medical_Insurance.Employee);
            return View(medical_Insurance);
        }

        // POST: Medical_Insurance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Insurance_ID,Insurance_Name,Insurance_Type,Coverage_Limit,Employee")] Medical_Insurance medical_Insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_Insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", medical_Insurance.Employee);
            return View(medical_Insurance);
        }

        // GET: Medical_Insurance/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Insurance medical_Insurance = db.Medical_Insurance.Find(id);
            if (medical_Insurance == null)
            {
                return HttpNotFound();
            }
            return View(medical_Insurance);
        }

        // POST: Medical_Insurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Medical_Insurance medical_Insurance = db.Medical_Insurance.Find(id);
            db.Medical_Insurance.Remove(medical_Insurance);
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
