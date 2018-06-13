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
    public class VehicleController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Vehicle
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Farm).Include(v => v.VehicleMake).Include(v => v.VehicleType);
            return View(vehicles.ToList());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName");
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr");
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,RegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,VehNextService,FarmID,VehTypeID,VehMakeID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.FarmID);
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.FarmID);
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,RegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,VehNextService,FarmID,VehTypeID,VehMakeID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.FarmID);
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
