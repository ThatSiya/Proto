using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmITApp.Models;
using FarmITApp.ViewModels;
using PagedList;

namespace FarmITApp.Controllers
{
    public class VehicleController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Vehicle
        public ActionResult Index(string vehicletype, string search, int? page)
        {
            //instatiate new view model
            VehicleIndexViewModel viewModel = new VehicleIndexViewModel();

            //select vehicles
            var vehicles = db.Vehicles.Include(v => v.Farm1).Include(v => v.Unit).Include(v => v.VehicleMake).Include(v => v.VehicleType);

            //do search and save search string in view model
            if (!String.IsNullOrEmpty(search))
            {
                vehicles = vehicles.Where(v => v.VehName.Contains(search) ||
                    v.VehModel.Contains(search) || v.VehicleType.VehTypeDescr.Contains(search));
                viewModel.Search = search;
            }

            //group search results into types and count how many workers in each type
            viewModel.VehTypesWithCount = from matchingVehicles in vehicles
                                              //where
                                              //matchingVehicles.VehicleID != null
                                          group matchingVehicles by
                                          matchingVehicles.VehicleType.VehTypeDescr into
                                          VehicleTypeGroup
                                          select new VehicleTypesWithCount()
                                          {
                                              VehTypeDescr = VehicleTypeGroup.Key,
                                              VehicleCount = VehicleTypeGroup.Count()
                                          };

            if (!String.IsNullOrEmpty(vehicletype))
            {
                vehicles = vehicles.Where(v => v.VehicleType.VehTypeDescr == vehicletype);
                viewModel.VehicleType = vehicletype;
            }

            //sort results
            vehicles = vehicles.OrderBy(i => i.VehicleID);
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
            ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName");
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr");
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr");
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,VehName,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,UnitID,VehNextService,Farm,VehTypeID,VehMakeID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.Farm);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr", vehicle.UnitID);
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
            ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.Farm);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr", vehicle.UnitID);
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleID,VehName,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,UnitID,VehNextService,Farm,VehTypeID,VehMakeID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.Farm);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr", vehicle.UnitID);
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
        public ActionResult EditMileage(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if(vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.Farm);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr", vehicle.UnitID);
            ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMileage([Bind(Include = "VehCurrMileage,VehServiceInterval,UnitID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Farm = new SelectList(db.Farms, "FarmID", "FarmName", vehicle.Farm);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "UnitDescr", vehicle.UnitID);
            //ViewBag.VehMakeID = new SelectList(db.VehicleMakes, "VehMakeID", "VehMakeDescr", vehicle.VehMakeID);
            //ViewBag.VehTypeID = new SelectList(db.VehicleTypes, "VehTypeID", "VehTypeDescr", vehicle.VehTypeID);
            return View(vehicle);
        }
    }
}
