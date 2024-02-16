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
    public class KT_DocumentsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: KT_Documents
        public ActionResult Index()
        {
            return View(db.KT_Documents.ToList());
        }

        // GET: KT_Documents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT_Documents kT_Documents = db.KT_Documents.Find(id);
            if (kT_Documents == null)
            {
                return HttpNotFound();
            }
            return View(kT_Documents);
        }

        // GET: KT_Documents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KT_Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KT_ID,KT_Name,Description")] KT_Documents kT_Documents)
        {
            if (ModelState.IsValid)
            {
                db.KT_Documents.Add(kT_Documents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kT_Documents);
        }

        // GET: KT_Documents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT_Documents kT_Documents = db.KT_Documents.Find(id);
            if (kT_Documents == null)
            {
                return HttpNotFound();
            }
            return View(kT_Documents);
        }

        // POST: KT_Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KT_ID,KT_Name,Description")] KT_Documents kT_Documents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kT_Documents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kT_Documents);
        }

        // GET: KT_Documents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KT_Documents kT_Documents = db.KT_Documents.Find(id);
            if (kT_Documents == null)
            {
                return HttpNotFound();
            }
            return View(kT_Documents);
        }

        // POST: KT_Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KT_Documents kT_Documents = db.KT_Documents.Find(id);
            db.KT_Documents.Remove(kT_Documents);
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
