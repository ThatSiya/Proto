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
    public class NaturalDisasterController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: NaturalDisaster
        public ActionResult Index()
        {
            return View(db.NaturalDisasters.ToList());
        }

        // GET: NaturalDisaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalDisaster naturalDisaster = db.NaturalDisasters.Find(id);
            if (naturalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(naturalDisaster);
        }

        // GET: NaturalDisaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaturalDisaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NatDisasterID,NatDisasterDescr,NatDisasterPrecautions,NatDisasterPotentialEffects,NatDisasterSigns")] NaturalDisaster naturalDisaster)
        {
            if (ModelState.IsValid)
            {
                db.NaturalDisasters.Add(naturalDisaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naturalDisaster);
        }

        // GET: NaturalDisaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalDisaster naturalDisaster = db.NaturalDisasters.Find(id);
            if (naturalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(naturalDisaster);
        }

        // POST: NaturalDisaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NatDisasterID,NatDisasterDescr,NatDisasterPrecautions,NatDisasterPotentialEffects,NatDisasterSigns")] NaturalDisaster naturalDisaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naturalDisaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(naturalDisaster);
        }

        // GET: NaturalDisaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaturalDisaster naturalDisaster = db.NaturalDisasters.Find(id);
            if (naturalDisaster == null)
            {
                return HttpNotFound();
            }
            return View(naturalDisaster);
        }

        // POST: NaturalDisaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NaturalDisaster naturalDisaster = db.NaturalDisasters.Find(id);
            db.NaturalDisasters.Remove(naturalDisaster);
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
