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
    public class VehicleServiceController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: VehicleService
        public ActionResult Index()
        {
            var vehicleServices = db.VehicleServices.Include(v => v.Vehicle);
            return View(vehicleServices.ToList());
        }

        // GET: VehicleService/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleService vehicleService = db.VehicleServices.Find(id);
            if (vehicleService == null)
            {
                return HttpNotFound();
            }
            return View(vehicleService);
        }

        // GET: VehicleService/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehName");
            return View();
        }

        // POST: VehicleService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleServiceID,VehicleService_Date,VehicleService_Cost,VehicleService_Mileage,VehicleServiceRecordUnit,VehicleID")] VehicleService vehicleService)
        {
            if (ModelState.IsValid)
            {
                db.VehicleServices.Add(vehicleService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehName", vehicleService.VehicleID);
            return View(vehicleService);
        }

        // GET: VehicleService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleService vehicleService = db.VehicleServices.Find(id);
            if (vehicleService == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehName", vehicleService.VehicleID);
            return View(vehicleService);
        }

        // POST: VehicleService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleServiceID,VehicleService_Date,VehicleService_Cost,VehicleService_Mileage,VehicleServiceRecordUnit,VehicleID")] VehicleService vehicleService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehName", vehicleService.VehicleID);
            return View(vehicleService);
        }

        // GET: VehicleService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleService vehicleService = db.VehicleServices.Find(id);
            if (vehicleService == null)
            {
                return HttpNotFound();
            }
            return View(vehicleService);
        }

        // POST: VehicleService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleService vehicleService = db.VehicleServices.Find(id);
            db.VehicleServices.Remove(vehicleService);
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
