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
    public class FieldController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Field
        public ActionResult Index()
        {
            var fields = db.Fields.Include(f => f.FieldStatu).Include(f => f.Land);
            return View(fields.ToList());
        }

        // GET: Field/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            ViewBag.Field_StatusID = new SelectList(db.FieldStatus, "FieldStatID", "FieldStatDescr");
            ViewBag.LandID = new SelectList(db.Lands, "LandID", "LandName");
            return View();
        }

        // POST: Field/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldID,FieldName,FieldHectares,Field_StatusID,LandID")] Field field)
        {
            if (ModelState.IsValid)
            {
                db.Fields.Add(field);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Field_StatusID = new SelectList(db.FieldStatus, "FieldStatID", "FieldStatDescr", field.Field_StatusID);
            ViewBag.LandID = new SelectList(db.Lands, "LandID", "LandName", field.LandID);
            return View(field);
        }

        // GET: Field/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            ViewBag.Field_StatusID = new SelectList(db.FieldStatus, "FieldStatID", "FieldStatDescr", field.Field_StatusID);
            ViewBag.LandID = new SelectList(db.Lands, "LandID", "LandName", field.LandID);
            return View(field);
        }

        // POST: Field/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldID,FieldName,FieldHectares,Field_StatusID,LandID")] Field field)
        {
            if (ModelState.IsValid)
            {
                db.Entry(field).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Field_StatusID = new SelectList(db.FieldStatus, "FieldStatID", "FieldStatDescr", field.Field_StatusID);
            ViewBag.LandID = new SelectList(db.Lands, "LandID", "LandName", field.LandID);
            return View(field);
        }

        // GET: Field/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // POST: Field/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Field field = db.Fields.Find(id);
            db.Fields.Remove(field);
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
