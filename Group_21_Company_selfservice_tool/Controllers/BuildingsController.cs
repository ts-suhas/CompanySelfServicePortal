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
    public class BuildingsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Buildings
        public ActionResult Index()
        {
            var building = db.Building.Include(b => b.Branch);
            return View(building.ToList());
        }

        // GET: Buildings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Building.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            ViewBag.Branch_ID = new SelectList(db.Branch, "Branch_ID", "Branch_Name");
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Building_ID,Building_Name,No_Of_Floors,No_Of_Rooms,Branch_ID")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Building.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Branch_ID = new SelectList(db.Branch, "Branch_ID", "Branch_Name", building.Branch_ID);
            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Building.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branch_ID = new SelectList(db.Branch, "Branch_ID", "Branch_Name", building.Branch_ID);
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Building_ID,Building_Name,No_Of_Floors,No_Of_Rooms,Branch_ID")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branch_ID = new SelectList(db.Branch, "Branch_ID", "Branch_Name", building.Branch_ID);
            return View(building);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Building.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Building building = db.Building.Find(id);
            db.Building.Remove(building);
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
