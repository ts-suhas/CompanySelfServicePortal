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
    public class ParkingsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Parkings
        public ActionResult Index()
        {
            var parking = db.Parking.Include(p => p.Employee1);
            return View(parking.ToList());
        }

        // GET: Parkings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parking.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // GET: Parkings/Create
        public ActionResult Create()
        {
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Parkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Parking_Lot_ID,Lot_Capacity,Location,Employee")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Parking.Add(parking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", parking.Employee);
            return View(parking);
        }

        // GET: Parkings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parking.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", parking.Employee);
            return View(parking);
        }

        // POST: Parkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Parking_Lot_ID,Lot_Capacity,Location,Employee")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", parking.Employee);
            return View(parking);
        }

        // GET: Parkings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parking.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: Parkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Parking parking = db.Parking.Find(id);
            db.Parking.Remove(parking);
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
