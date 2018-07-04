using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class FarmWorkerTypeController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: FarmWorkerType
        public ActionResult Index()
        {
            return View(db.FarmWorkerTypes.ToList());
        }

        // GET: FarmWorkerType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorkerType farmWorkerType = db.FarmWorkerTypes.Find(id);
            if (farmWorkerType == null)
            {
                return HttpNotFound();
            }
            return View(farmWorkerType);
        }

        // GET: FarmWorkerType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmWorkerType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmWorkerTypeID,FarmWorkerTypeDescr,FarmWorkerTypeNotes,FarmWorkerTypeActiveStatus")] FarmWorkerType farmWorkerType)
        {
            if (ModelState.IsValid)
            {
                db.FarmWorkerTypes.Add(farmWorkerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmWorkerType);
        }

        // GET: FarmWorkerType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorkerType farmWorkerType = db.FarmWorkerTypes.Find(id);
            if (farmWorkerType == null)
            {
                return HttpNotFound();
            }
            return View(farmWorkerType);
        }

        // POST: FarmWorkerType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmWorkerTypeID,FarmWorkerTypeDescr,FarmWorkerTypeNotes,FarmWorkerTypeActiveStatus")] FarmWorkerType farmWorkerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmWorkerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmWorkerType);
        }

        // GET: FarmWorkerType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorkerType farmWorkerType = db.FarmWorkerTypes.Find(id);
            if (farmWorkerType == null)
            {
                return HttpNotFound();
            }
            return View(farmWorkerType);
        }

        // POST: FarmWorkerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FarmWorkerType farmWorkerType = db.FarmWorkerTypes.Find(id);
            db.FarmWorkerTypes.Remove(farmWorkerType);
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
