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
    public class Work_ModeController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Work_Mode
        public ActionResult Index()
        {
            return View(db.Work_Mode.ToList());
        }

        // GET: Work_Mode/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Mode work_Mode = db.Work_Mode.Find(id);
            if (work_Mode == null)
            {
                return HttpNotFound();
            }
            return View(work_Mode);
        }

        // GET: Work_Mode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Mode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mode_ID,Mode_Name,Description")] Work_Mode work_Mode)
        {
            if (ModelState.IsValid)
            {
                db.Work_Mode.Add(work_Mode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Mode);
        }

        // GET: Work_Mode/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Mode work_Mode = db.Work_Mode.Find(id);
            if (work_Mode == null)
            {
                return HttpNotFound();
            }
            return View(work_Mode);
        }

        // POST: Work_Mode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mode_ID,Mode_Name,Description")] Work_Mode work_Mode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Mode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Mode);
        }

        // GET: Work_Mode/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Mode work_Mode = db.Work_Mode.Find(id);
            if (work_Mode == null)
            {
                return HttpNotFound();
            }
            return View(work_Mode);
        }

        // POST: Work_Mode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Work_Mode work_Mode = db.Work_Mode.Find(id);
            db.Work_Mode.Remove(work_Mode);
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
