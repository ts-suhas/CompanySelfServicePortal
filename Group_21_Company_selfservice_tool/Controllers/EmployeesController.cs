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
    public class EmployeesController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = db.Employee.Include(e => e.Meal_Plan).Include(e => e.Project).Include(e => e.Role).Include(e => e.Work_Mode).Include(e => e.Leaves);
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.MealPlan_ID = new SelectList(db.Meal_Plan, "Meal_Plan_ID", "Meal_Plan_Name");
            ViewBag.Project_ID = new SelectList(db.Project, "Project_ID", "Project_Name");
            ViewBag.Role_ID = new SelectList(db.Role, "Role_ID", "Role_Type");
            ViewBag.Mode_ID = new SelectList(db.Work_Mode, "Mode_ID", "Mode_Name");
            ViewBag.Employee_ID = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Employee_First_Name,Employee_Last_Name,Designation_ID,Company_Email,Company_Phone,Employee_Start_Date,Mode_ID,Project_ID,Role_ID,MealPlan_ID,Admin_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MealPlan_ID = new SelectList(db.Meal_Plan, "Meal_Plan_ID", "Meal_Plan_Name", employee.MealPlan_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "Project_ID", "Project_Name", employee.Project_ID);
            ViewBag.Role_ID = new SelectList(db.Role, "Role_ID", "Role_Type", employee.Role_ID);
            ViewBag.Mode_ID = new SelectList(db.Work_Mode, "Mode_ID", "Mode_Name", employee.Mode_ID);
            ViewBag.Employee_ID = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", employee.Employee_ID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.MealPlan_ID = new SelectList(db.Meal_Plan, "Meal_Plan_ID", "Meal_Plan_Name", employee.MealPlan_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "Project_ID", "Project_Name", employee.Project_ID);
            ViewBag.Role_ID = new SelectList(db.Role, "Role_ID", "Role_Type", employee.Role_ID);
            ViewBag.Mode_ID = new SelectList(db.Work_Mode, "Mode_ID", "Mode_Name", employee.Mode_ID);
            ViewBag.Employee_ID = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", employee.Employee_ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Employee_First_Name,Employee_Last_Name,Designation_ID,Company_Email,Company_Phone,Employee_Start_Date,Mode_ID,Project_ID,Role_ID,MealPlan_ID,Admin_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MealPlan_ID = new SelectList(db.Meal_Plan, "Meal_Plan_ID", "Meal_Plan_Name", employee.MealPlan_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "Project_ID", "Project_Name", employee.Project_ID);
            ViewBag.Role_ID = new SelectList(db.Role, "Role_ID", "Role_Type", employee.Role_ID);
            ViewBag.Mode_ID = new SelectList(db.Work_Mode, "Mode_ID", "Mode_Name", employee.Mode_ID);
            ViewBag.Employee_ID = new SelectList(db.Leaves, "Leave_Balance_ID", "Leave_Type", employee.Employee_ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
