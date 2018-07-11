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
        public ActionResult Index(string vehicletype, string search, int? page)
        {
            //instatiate new view model
            VehicleIndexViewModel viewModel = new VehicleIndexViewModel();

            //select vehicles
            var vehicles = db.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleMake);
            //var farmWorkers = db.FarmWorkers.Include(f => f.FarmWorkerType).Include(f => f.Gender).Include(f => f.Title);

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
        //Return VehicleServices for the selected vehicle
        public ActionResult ServiceIndex(int? id)
        {
            var vehicleServices = db.VehicleServices.Include(v => v.Vehicle).Where(v => v.VehicleID == id);
            return View(vehicleServices);
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

        //Update Vehicle Mileage

        // GET: Vehicle/EditMileage/5
        public ActionResult EditMileage(int? id)
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

        // GET: VehicleService/Edit/5
        public ActionResult EditService(int? id)
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
        public ActionResult EditService([Bind(Include = "VehicleServiceID,VehicleService_Date,VehicleService_Cost,VehicleService_Mileage,VehicleServiceRecordUnit,VehicleID")] VehicleService vehicleService)
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

        // GET: VehicleService/Create
        public ActionResult CreateVehicleService(int? id)
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
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehName", vehicle.VehicleID);
            return View();
        }

        // POST: VehicleService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVehicleService([Bind(Include = "VehicleServiceID,VehicleService_Date,VehicleService_Cost,VehicleService_Mileage,VehicleServiceRecordUnit,VehicleID")] VehicleService vehicleService)
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

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMileage([Bind(Include = "VehicleID,VehName,VehYear,VehModel,VehEngineNum,VehVinNum,VehRegNum,VehLicenseNum,VehExpDate,VehCurrMileage,VehServiceInterval,VehServiceIntervalUnit,VehNextService,FarmID,VehTypeID,VehMakeID")] Vehicle vehicle)
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
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VehicleService vehicleService = db.VehicleServices.Find(id);
            //if (vehicleService == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vehicleService);
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