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
    public class Meal_PlanController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Meal_Plan
        public ActionResult Index()
        {
            return View(db.Meal_Plan.ToList());
        }

        // GET: Meal_Plan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal_Plan meal_Plan = db.Meal_Plan.Find(id);
            if (meal_Plan == null)
            {
                return HttpNotFound();
            }
            return View(meal_Plan);
        }

        // GET: Meal_Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meal_Plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Meal_Plan_ID,Meal_Plan_Name,Description")] Meal_Plan meal_Plan)
        {
            if (ModelState.IsValid)
            {
                db.Meal_Plan.Add(meal_Plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meal_Plan);
        }

        // GET: Meal_Plan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal_Plan meal_Plan = db.Meal_Plan.Find(id);
            if (meal_Plan == null)
            {
                return HttpNotFound();
            }
            return View(meal_Plan);
        }

        // POST: Meal_Plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Meal_Plan_ID,Meal_Plan_Name,Description")] Meal_Plan meal_Plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal_Plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal_Plan);
        }

        // GET: Meal_Plan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal_Plan meal_Plan = db.Meal_Plan.Find(id);
            if (meal_Plan == null)
            {
                return HttpNotFound();
            }
            return View(meal_Plan);
        }

        // POST: Meal_Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Meal_Plan meal_Plan = db.Meal_Plan.Find(id);
            db.Meal_Plan.Remove(meal_Plan);
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
