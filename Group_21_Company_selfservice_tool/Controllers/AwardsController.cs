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
    public class AwardsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Awards
        public ActionResult Index()
        {
            var awards = db.Awards.Include(a => a.Employee);
            return View(awards.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awards awards = db.Awards.Find(id);
            if (awards == null)
            {
                return HttpNotFound();
            }
            return View(awards);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Award_ID,Award_Name,Description,Employee_ID")] Awards awards)
        {
            if (ModelState.IsValid)
            {
                db.Awards.Add(awards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", awards.Employee_ID);
            return View(awards);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awards awards = db.Awards.Find(id);
            if (awards == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", awards.Employee_ID);
            return View(awards);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Award_ID,Award_Name,Description,Employee_ID")] Awards awards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(awards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", awards.Employee_ID);
            return View(awards);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Awards awards = db.Awards.Find(id);
            if (awards == null)
            {
                return HttpNotFound();
            }
            return View(awards);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Awards awards = db.Awards.Find(id);
            db.Awards.Remove(awards);
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
