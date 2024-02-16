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
    public class SkillsetsController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Skillsets
        public ActionResult Index()
        {
            return View(db.Skillset.ToList());
        }

        // GET: Skillsets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skillset skillset = db.Skillset.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // GET: Skillsets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skillsets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Skill_ID,Skill_Name")] Skillset skillset)
        {
            if (ModelState.IsValid)
            {
                db.Skillset.Add(skillset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillset);
        }

        // GET: Skillsets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skillset skillset = db.Skillset.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // POST: Skillsets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Skill_ID,Skill_Name")] Skillset skillset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillset);
        }

        // GET: Skillsets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skillset skillset = db.Skillset.Find(id);
            if (skillset == null)
            {
                return HttpNotFound();
            }
            return View(skillset);
        }

        // POST: Skillsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Skillset skillset = db.Skillset.Find(id);
            db.Skillset.Remove(skillset);
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
