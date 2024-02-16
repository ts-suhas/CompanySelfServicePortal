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
    public class LeavesController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Leaves
        public ActionResult Index()
        {
            var leaves = db.Leaves.Include(l => l.Employee1);
            return View(leaves.ToList());
        }

        // GET: Leaves/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaves leaves = db.Leaves.Find(id);
            if (leaves == null)
            {
                return HttpNotFound();
            }
            return View(leaves);
        }

        // GET: Leaves/Create
        public ActionResult Create()
        {
            ViewBag.Leave_Balance_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Leave_Balance_ID,Leave_Type,Assigned_Leaves,Leaves_Taken_In_Month,employee")] Leaves leaves)
        {
            if (ModelState.IsValid)
            {
                db.Leaves.Add(leaves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Leave_Balance_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", leaves.Leave_Balance_ID);
            return View(leaves);
        }

        // GET: Leaves/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaves leaves = db.Leaves.Find(id);
            if (leaves == null)
            {
                return HttpNotFound();
            }
            ViewBag.Leave_Balance_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", leaves.Leave_Balance_ID);
            return View(leaves);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Leave_Balance_ID,Leave_Type,Assigned_Leaves,Leaves_Taken_In_Month,employee")] Leaves leaves)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaves).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Leave_Balance_ID = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", leaves.Leave_Balance_ID);
            return View(leaves);
        }

        // GET: Leaves/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leaves leaves = db.Leaves.Find(id);
            if (leaves == null)
            {
                return HttpNotFound();
            }
            return View(leaves);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Leaves leaves = db.Leaves.Find(id);
            db.Leaves.Remove(leaves);
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
