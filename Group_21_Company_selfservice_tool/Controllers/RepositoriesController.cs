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
    public class RepositoriesController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Repositories
        public ActionResult Index()
        {
            var repository = db.Repository.Include(r => r.Department1);
            return View(repository.ToList());
        }

        // GET: Repositories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository repository = db.Repository.Find(id);
            if (repository == null)
            {
                return HttpNotFound();
            }
            return View(repository);
        }

        // GET: Repositories/Create
        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.Department, "Department_ID", "Head");
            return View();
        }

        // POST: Repositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Repository_ID,Storage_Available,Department")] Repository repository)
        {
            if (ModelState.IsValid)
            {
                db.Repository.Add(repository);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department = new SelectList(db.Department, "Department_ID", "Head", repository.Department);
            return View(repository);
        }

        // GET: Repositories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository repository = db.Repository.Find(id);
            if (repository == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department = new SelectList(db.Department, "Department_ID", "Head", repository.Department);
            return View(repository);
        }

        // POST: Repositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Repository_ID,Storage_Available,Department")] Repository repository)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repository).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.Department, "Department_ID", "Head", repository.Department);
            return View(repository);
        }

        // GET: Repositories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository repository = db.Repository.Find(id);
            if (repository == null)
            {
                return HttpNotFound();
            }
            return View(repository);
        }

        // POST: Repositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Repository repository = db.Repository.Find(id);
            db.Repository.Remove(repository);
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
