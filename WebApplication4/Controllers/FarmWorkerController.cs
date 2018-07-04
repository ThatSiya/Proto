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
    public class FarmWorkerController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: FarmWorker
        public ActionResult Index(string farmworkertype, string search, int? page)
        {
            //instatiate new view model
            FarmWorkerIndexViewModel viewModel = new FarmWorkerIndexViewModel();

            //select farmworkers
            var farmWorkers = db.FarmWorkers.Include(i => i.FarmWorkerType);
            //var farmWorkers = db.FarmWorkers.Include(f => f.FarmWorkerType).Include(f => f.Gender).Include(f => f.Title);

            //do search and save search string in view model
            if (!String.IsNullOrEmpty(search))
            {
                farmWorkers = farmWorkers.Where(i => i.FarmWorkerFName.Contains(search) ||
                    i.FarmWorkerLName.Contains(search) || i.FarmWorkerType.FarmWorkerTypeDescr.Contains(search));
                viewModel.Search = search;
            }

            //group search results into types and count how many workers in each type
            viewModel.WorkerTypesWithCount = from matchingFarmWorkers in farmWorkers
                                             where
                                             matchingFarmWorkers.FarmWorkerTypeID != null
                                             group matchingFarmWorkers by
                                             matchingFarmWorkers.FarmWorkerType.FarmWorkerTypeDescr into
                                             FarmWorkerTypeGroup
                                             select new FarmWorkerTypesWithCount()
                                             {
                                                 FarmWorkerTypeDescr = FarmWorkerTypeGroup.Key,
                                                 FarmWorkerCount = FarmWorkerTypeGroup.Count()
                                             };

            if (!String.IsNullOrEmpty(farmworkertype))
            {
                farmWorkers = farmWorkers.Where(i => i.FarmWorkerType.FarmWorkerTypeDescr == farmworkertype);
                viewModel.FarmWorkerType = farmworkertype;
            }

            //sort results
            farmWorkers = farmWorkers.OrderBy(i => i.FarmWorkerLName);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.FarmWorkers = farmWorkers.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: FarmWorker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorker farmWorker = db.FarmWorkers.Find(id);
            if (farmWorker == null)
            {
                return HttpNotFound();
            }
            return View(farmWorker);
        }

        // GET: FarmWorker/Create
        public ActionResult Create()
        {
            ViewBag.FarmWorkerTypeID = new SelectList(db.FarmWorkerTypes, "FarmWorkerTypeID", "FarmWorkerTypeDescr");
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderDescr");
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescr");
            return View();
        }

        // POST: FarmWorker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmWorkerNum,FarmWorkerFName,FarmWorkerLName,FarmWorkerContactNum,Address,Surburb,City,Province,Country,ContractStartDate,ContractEndDate,FarmWorkerIDNum,TitleID,GenderID,FarmWorkerTypeID")] FarmWorker farmWorker)
        {
            if (ModelState.IsValid)
            {
                db.FarmWorkers.Add(farmWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmWorkerTypeID = new SelectList(db.FarmWorkerTypes, "FarmWorkerTypeID", "FarmWorkerTypeDescr", farmWorker.FarmWorkerTypeID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderDescr", farmWorker.GenderID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescr", farmWorker.TitleID);
            return View(farmWorker);
        }

        // GET: FarmWorker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorker farmWorker = db.FarmWorkers.Find(id);
            if (farmWorker == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmWorkerTypeID = new SelectList(db.FarmWorkerTypes, "FarmWorkerTypeID", "FarmWorkerTypeDescr", farmWorker.FarmWorkerTypeID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderDescr", farmWorker.GenderID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescr", farmWorker.TitleID);
            return View(farmWorker);
        }

        // POST: FarmWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmWorkerNum,FarmWorkerFName,FarmWorkerLName,FarmWorkerContactNum,Address,Surburb,City,Province,Country,ContractStartDate,ContractEndDate,FarmWorkerIDNum,TitleID,GenderID,FarmWorkerTypeID")] FarmWorker farmWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmWorkerTypeID = new SelectList(db.FarmWorkerTypes, "FarmWorkerTypeID", "FarmWorkerTypeDescr", farmWorker.FarmWorkerTypeID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "GenderDescr", farmWorker.GenderID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "TitleDescr", farmWorker.TitleID);
            return View(farmWorker);
        }

        // GET: FarmWorker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmWorker farmWorker = db.FarmWorkers.Find(id);
            if (farmWorker == null)
            {
                return HttpNotFound();
            }
            return View(farmWorker);
        }

        // POST: FarmWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FarmWorker farmWorker = db.FarmWorkers.Find(id);
            db.FarmWorkers.Remove(farmWorker);
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
