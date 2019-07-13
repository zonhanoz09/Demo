using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.Models.Classes;

namespace Demo.Controllers
{
    public class DemoTablesController : BaseController
    {
        // GET: DemoTables
        public ActionResult Index()
        {
            return View(db.DemoTable.ToList());
        }

        // GET: DemoTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTable.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // GET: DemoTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemoTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StepID,StepName,Description,IsActive,LastUpdated,LastUpdatedBy")] DemoTable demoTable)
        {
            if (ModelState.IsValid)
            {
                db.DemoTable.Add(demoTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demoTable);
        }

        // GET: DemoTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTable.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // POST: DemoTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StepID,StepName,Description,IsActive,LastUpdated,LastUpdatedBy")] DemoTable demoTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demoTable);
        }

        // GET: DemoTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoTable demoTable = db.DemoTable.Find(id);
            if (demoTable == null)
            {
                return HttpNotFound();
            }
            return View(demoTable);
        }

        // POST: DemoTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemoTable demoTable = db.DemoTable.Find(id);
            db.DemoTable.Remove(demoTable);
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
