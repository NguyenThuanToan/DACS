using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS.Models;

namespace DACS.Areas.Admin.Controllers
{
    public class ETaskController : Controller
    {
        private DACSModelContext db = new DACSModelContext();

        // GET: Admin/ETask
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Position);
            return View(employees.ToList());
        }

        // GET: Admin/ETask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/ETask/Create
        public ActionResult Create()
        {
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1");
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "idNv");
            ViewBag.EmployeeName = new SelectList(db.Employees, "idNv", "EmployeeName");
            return View();
        }

        // POST: Admin/ETask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNv,IdPos,EmployeeName,NumberPhone,Sex,imageEmployee")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", employee.IdPos);
            return View(employee);
        }

        // GET: Admin/ETask/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1");
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "idNv");
            ViewBag.EmployeeName = new SelectList(db.Employees, "idNv", "EmployeeName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", employee.IdPos);
            return View(employee);
        }

        // POST: Admin/ETask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNv,IdPos,EmployeeName,NumberPhone,Sex,imageEmployee")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", employee.IdPos);
            return View(employee);
        }

        // GET: Admin/ETask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/ETask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
