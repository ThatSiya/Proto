using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmITApp.Models;

namespace FarmITApp.Controllers
{
    public class CropTypeController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: CropType
        public ActionResult Index()
        {
            return View(db.CropTypes.ToList());
        }

        // GET: CropType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropType cropType = db.CropTypes.Find(id);
            if (cropType == null)
            {
                return HttpNotFound();
            }
            return View(cropType);
        }

        // GET: CropType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CropType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CropTypeID,CropTypeDescr,MaturityDays")] CropType cropType)
        {
            if (ModelState.IsValid)
            {
                db.CropTypes.Add(cropType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cropType);
        }

        // GET: CropType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropType cropType = db.CropTypes.Find(id);
            if (cropType == null)
            {
                return HttpNotFound();
            }
            return View(cropType);
        }

        // POST: CropType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CropTypeID,CropTypeDescr,MaturityDays")] CropType cropType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cropType);
        }

        // GET: CropType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropType cropType = db.CropTypes.Find(id);
            if (cropType == null)
            {
                return HttpNotFound();
            }
            return View(cropType);
        }

        // POST: CropType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropType cropType = db.CropTypes.Find(id);
            db.CropTypes.Remove(cropType);
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
