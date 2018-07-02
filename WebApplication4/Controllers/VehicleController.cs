using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.ViewModels;
using PagedList;

namespace WebApplication4.Controllers
{
    public class VehicleController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Vehicle
        public ActionResult Index(string vehicletype,string search, int? page)
        {
            VehicleIndexViewModel viewModel = new VehicleIndexViewModel();
            var vehicles = db.Vehicles.Include(v => v.VehicleType);

            if (!String.IsNullOrEmpty(search))
            {
                vehicles = vehicles.Where(v => v.VehName.Contains(search) ||
                v.VehicleType.VehTypeDescr.Contains(search));
                ViewBag.Search = search;
            }
            viewModel.VehTypesWithCount = from matchingVehicles in vehicles
                                          where
                                          matchingVehicles.VehTypeID != null
                                          group matchingVehicles by
                                          matchingVehicles.VehicleType.VehTypeDescr into
                                          VehTypeGroup
                                          select new VehicleTypesWithCount()
                                          {
                                              VehTypeDescr = VehTypeGroup.Key,
                                              VehicleCount = VehTypeGroup.Count()
                                          };

            if (!String.IsNullOrEmpty(vehicletype))
            {
                vehicles = vehicles.Where(i => i.VehicleType.VehTypeDescr == vehicletype);
                viewModel.VehicleType = vehicletype;
            }
            //ViewBag.InventoryType = new SelectList(inventorytypes);
            //Search is stored in the ViewBag to allow it to be reused when a user clicks on the: inventory type filter

            //viewModel.Inventories = inventories.OrderBy(c => c.InvDescr);

            //sort results
            vehicles = vehicles.OrderBy(i => i.VehName);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Vehicles = vehicles.ToPagedList(currentPage, PageItems);
            return View(viewModel);
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
        public ActionResult Create([Bind(Include = "VehicleID,VehName,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,VehServiceIntervalUnit,VehNextService,FarmID,VehTypeID,VehMakeID")] Vehicle vehicle)
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
        public ActionResult Edit([Bind(Include = "VehicleID,VehName,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,VehServiceIntervalUnit,VehNextService,FarmID,VehTypeID,VehMakeID")] Vehicle vehicle)
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
