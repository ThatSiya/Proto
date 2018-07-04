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
    public class BiologicalDisasterController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: BiologicalDisaster
        public ActionResult Index()
        {
            return View(db.BiologicalDisasters.ToList());
        }

        // GET: BiologicalDisaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiologicalDisaster biologicalDisaster = db.BiologicalDisasters.Find(id);
            if (biologicalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(biologicalDisaster);
        }

        // GET: BiologicalDisaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BiologicalDisaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BioDisasterID,BioDisasterDescr,BioDisasterNotes")] BiologicalDisaster biologicalDisaster)
        {
            if (ModelState.IsValid)
            {
                db.BiologicalDisasters.Add(biologicalDisaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biologicalDisaster);
        }

        // GET: BiologicalDisaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiologicalDisaster biologicalDisaster = db.BiologicalDisasters.Find(id);
            if (biologicalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(biologicalDisaster);
        }

        // POST: BiologicalDisaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BioDisasterID,BioDisasterDescr,BioDisasterNotes")] BiologicalDisaster biologicalDisaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biologicalDisaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biologicalDisaster);
        }

        // GET: BiologicalDisaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiologicalDisaster biologicalDisaster = db.BiologicalDisasters.Find(id);
            if (biologicalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(biologicalDisaster);
        }

        // POST: BiologicalDisaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiologicalDisaster biologicalDisaster = db.BiologicalDisasters.Find(id);
            db.BiologicalDisasters.Remove(biologicalDisaster);
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
