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
    public class tasksController : Controller
    {
        private DACSModelContext db = new DACSModelContext();

        // GET: Admin/tasks
        public ActionResult Index()
        {
            var tasks = db.tasks.Include(t => t.Employee).Include(t => t.Position);
            return View(tasks.ToList());
        }

        // GET: Admin/tasks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Admin/tasks/Create
        public ActionResult Create()
        {
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "idNv");
            ViewBag.EmployeeName = new SelectList(db.Employees, "idNv", "EmployeeName");
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1");
            return View();
        }

        // POST: Admin/tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeName,IdPos,idNv,TaskDetails")] task task)
        {
            if (ModelState.IsValid)
            {
                db.tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "EmployeeName", task.idNv);
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", task.IdPos);
            return View(task);
        }
        // GET: Admin/tasks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "EmployeeName", task.idNv);
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", task.IdPos);
            return View(task);
        }

        // POST: Admin/tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeName,IdPos,idNv,TaskDetails")] task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNv = new SelectList(db.Employees, "idNv", "EmployeeName", task.idNv);
            ViewBag.IdPos = new SelectList(db.Positions, "IdPos", "Position1", task.IdPos);
            return View(task);
        }

        // GET: Admin/tasks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Admin/tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            task task = db.tasks.Find(id);
            db.tasks.Remove(task);
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
