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
    public class PlantationController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Plantation
        public ActionResult Index(string search, int? page, string croptype)
        {
            //instantiate new view model
            PlantationViewModel viewModel = new PlantationViewModel();

            //select plantations
            var plantations = db.Plantations.Include(p => p.CropType).Include(p=>p.CropCycle);

            //group search results into types and count how many items in each type
            viewModel.cropTypesWithCount = from matchingPlantations in plantations
                                          group matchingPlantations by
                                          matchingPlantations.CropType.CropTypeDescr into
                                          CropTypeGroup
                                          select new CropTypesWithCount()
                                          {
                                              CropTypeDescr = CropTypeGroup.Key,
                                              PlantationCount = CropTypeGroup.Count()
                                          };

            if (!String.IsNullOrEmpty(croptype))
            {
                plantations = plantations.Where(i => i.CropType.CropTypeDescr == croptype);
                viewModel.CropType = croptype;
            }

            //sort results
            plantations = plantations.OrderBy(i => i.PlantationID);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Plantations = plantations.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: Plantation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            return View(plantation);
        }

        // GET: Plantation/Create
        public ActionResult Create()
        {
            ViewBag.CropCycleID = new SelectList(db.CropCycles, "CropCycleID", "CropCycleDescr");
            ViewBag.CropTypeID = new SelectList(db.CropTypes, "CropTypeID", "CropTypeDescr");
            ViewBag.FieldID = new SelectList(db.Fields, "FieldID", "FieldName");
            ViewBag.FieldStageID = new SelectList(db.FieldStages, "FieldStageID", "FieldStageDescr");
            return View();
        }

        // POST: Plantation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantationID,FieldID,CropTypeID,CropCycleID,FieldStageID,DatePlanted,RefugeSeedAmntUsed,RefugeSeedUnit,RefugeAreaHectares,ExpectedYieldQnty,ExpectedYieldUnit,DateHarvested,PlantationStatus")] Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                db.Plantations.Add(plantation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CropCycleID = new SelectList(db.CropCycles, "CropCycleID", "CropCycleDescr", plantation.CropCycleID);
            ViewBag.CropTypeID = new SelectList(db.CropTypes, "CropTypeID", "CropTypeDescr", plantation.CropTypeID);
            ViewBag.FieldID = new SelectList(db.Fields, "FieldID", "FieldName", plantation.FieldID);
            ViewBag.FieldStageID = new SelectList(db.FieldStages, "FieldStageID", "FieldStageDescr", plantation.FieldStageID);
            return View(plantation);
        }

        // GET: Plantation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CropCycleID = new SelectList(db.CropCycles, "CropCycleID", "CropCycleDescr", plantation.CropCycleID);
            ViewBag.CropTypeID = new SelectList(db.CropTypes, "CropTypeID", "CropTypeDescr", plantation.CropTypeID);
            ViewBag.FieldID = new SelectList(db.Fields, "FieldID", "FieldName", plantation.FieldID);
            ViewBag.FieldStageID = new SelectList(db.FieldStages, "FieldStageID", "FieldStageDescr", plantation.FieldStageID);
            return View(plantation);
        }

        // POST: Plantation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantationID,FieldID,CropTypeID,CropCycleID,FieldStageID,DatePlanted,RefugeSeedAmntUsed,RefugeSeedUnit,RefugeAreaHectares,ExpectedYieldQnty,ExpectedYieldUnit,DateHarvested,PlantationStatus")] Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CropCycleID = new SelectList(db.CropCycles, "CropCycleID", "CropCycleDescr", plantation.CropCycleID);
            ViewBag.CropTypeID = new SelectList(db.CropTypes, "CropTypeID", "CropTypeDescr", plantation.CropTypeID);
            ViewBag.FieldID = new SelectList(db.Fields, "FieldID", "FieldName", plantation.FieldID);
            ViewBag.FieldStageID = new SelectList(db.FieldStages, "FieldStageID", "FieldStageDescr", plantation.FieldStageID);
            return View(plantation);
        }

        // GET: Plantation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            return View(plantation);
        }

        // POST: Plantation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plantation plantation = db.Plantations.Find(id);
            db.Plantations.Remove(plantation);
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
