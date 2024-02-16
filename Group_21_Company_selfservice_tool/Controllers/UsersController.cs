using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group_21_Company_selfservice_tool.Models;
using System.Data.SqlClient;


namespace Group_21_Company_selfservice_tool.Controllers
{
    public class UsersController : Controller
    {
        private FDBProjectEntities3 db = new FDBProjectEntities3();

        // GET: Users
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.Employee1).Include(u => u.Room);
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name");
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Room_No");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,Username,Password,Room_ID,employee")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", user.employee);
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Room_No", user.Room_ID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", user.employee);
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Room_No", user.Room_ID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,Username,Password,Room_ID,employee")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee = new SelectList(db.Employee, "Employee_ID", "Employee_First_Name", user.employee);
            ViewBag.Room_ID = new SelectList(db.Room, "Room_ID", "Room_No", user.Room_ID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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

        // Verify UserPasswords
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        void connectionString()
        {
            conn.ConnectionString = "Data Source=DESKTOP-7UQ6PKP;Initial Catalog=FDBProject;Integrated Security=True";


        }


        [HttpPost]
        public ActionResult Verify(User login)
        {
            connectionString();
            conn.Open();

            com.Connection = conn;

            com.CommandText = "select * FROM [FDBProject].[dbo].[User] where [Username]='" + login.Username + "' and [Password]='" + login.Password + "'";

            dr = com.ExecuteReader();

            if (dr.Read())
            {
                conn.Close();



                if ((login.Username == "suhas") && (login.Password == "sahus"))
                {
                    return View("admin");
                }
                else
                {
                    return View("normal");
                }


            }
            else
            {
                conn.Close();
                return View("Error");
            }
        }

    }
}
