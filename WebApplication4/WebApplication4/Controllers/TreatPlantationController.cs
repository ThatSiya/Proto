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
    public class TreatPlantationController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: TreatPlantation
        public ActionResult Index()
        {
            var inventoryTreatments = db.InventoryTreatments.Include(i => i.Inventory).Include(i => i.Treatment);
            return View(inventoryTreatments.ToList());
        }

        // GET: TreatPlantation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTreatment inventoryTreatment = db.InventoryTreatments.Find(id);
            if (inventoryTreatment == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTreatment);
        }

        // GET: TreatPlantation/Create
        public ActionResult Create()
        {
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "InvDescr");
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentDescr");
            return View();
        }

        // POST: TreatPlantation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentID,InventoryID,TreatmentQnty,TreatmentUnit")] InventoryTreatment inventoryTreatment)
        {
            if (ModelState.IsValid)
            {
                db.InventoryTreatments.Add(inventoryTreatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "InvDescr", inventoryTreatment.InventoryID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentDescr", inventoryTreatment.TreatmentID);
            return View(inventoryTreatment);
        }

        // GET: TreatPlantation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTreatment inventoryTreatment = db.InventoryTreatments.Find(id);
            if (inventoryTreatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "InvDescr", inventoryTreatment.InventoryID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentDescr", inventoryTreatment.TreatmentID);
            return View(inventoryTreatment);
        }

        // POST: TreatPlantation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentID,InventoryID,TreatmentQnty,TreatmentUnit")] InventoryTreatment inventoryTreatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryTreatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "InvDescr", inventoryTreatment.InventoryID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentDescr", inventoryTreatment.TreatmentID);
            return View(inventoryTreatment);
        }

        // GET: TreatPlantation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTreatment inventoryTreatment = db.InventoryTreatments.Find(id);
            if (inventoryTreatment == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTreatment);
        }

        // POST: TreatPlantation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryTreatment inventoryTreatment = db.InventoryTreatments.Find(id);
            db.InventoryTreatments.Remove(inventoryTreatment);
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
