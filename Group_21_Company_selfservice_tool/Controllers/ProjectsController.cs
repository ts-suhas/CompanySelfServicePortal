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
    public class ProjectsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Projects
        public ActionResult Index()
        {
            var project = db.Project.Include(p => p.Client).Include(p => p.Department);
            return View(project.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.Client_ID = new SelectList(db.Client, "Client_ID", "Client_Name");
            ViewBag.Department_ID = new SelectList(db.Department, "Department_ID", "Head");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_ID,Project_Name,Project_Budget,Project_Members,Project_Start_Date,Project_End_Date,Client_ID,Department_ID")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client_ID = new SelectList(db.Client, "Client_ID", "Client_Name", project.Client_ID);
            ViewBag.Department_ID = new SelectList(db.Department, "Department_ID", "Head", project.Department_ID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_ID = new SelectList(db.Client, "Client_ID", "Client_Name", project.Client_ID);
            ViewBag.Department_ID = new SelectList(db.Department, "Department_ID", "Head", project.Department_ID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_ID,Project_Name,Project_Budget,Project_Members,Project_Start_Date,Project_End_Date,Client_ID,Department_ID")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_ID = new SelectList(db.Client, "Client_ID", "Client_Name", project.Client_ID);
            ViewBag.Department_ID = new SelectList(db.Department, "Department_ID", "Head", project.Department_ID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Project project = db.Project.Find(id);
            db.Project.Remove(project);
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
