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
    public class CropCycleController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: CropCycle
        public ActionResult Index(int? page, string search)
        {
            CropCycleIndexViewModel viewModel = new CropCycleIndexViewModel();
            var cropcycles = db.CropCycles.Include(c => c.Plantations);
            if (!String.IsNullOrEmpty(search))
            {
                cropcycles = db.CropCycles.Where(c => c.CropCycleDescr.Contains(search));
                //ViewBag.Search = search;
                viewModel.Search = search;
            }
            //sort results
            cropcycles = cropcycles.OrderBy(c => c.CropCycleDescr);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.CropCycles = cropcycles.ToPagedList(currentPage,PageItems);
            return View(viewModel);
        }

        // GET: CropCycle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropCycle cropCycle = db.CropCycles.Find(id);
            if (cropCycle == null)
            {
                return HttpNotFound();
            }
            return View(cropCycle);
        }

        // GET: CropCycle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CropCycle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CropCycleID,CropCycleStartDate,CropCycleEndDate,CropCycleDescr")] CropCycle cropCycle)
        {
            if (ModelState.IsValid)
            {
                db.CropCycles.Add(cropCycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cropCycle);
        }

        // GET: CropCycle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropCycle cropCycle = db.CropCycles.Find(id);
            if (cropCycle == null)
            {
                return HttpNotFound();
            }
            return View(cropCycle);
        }

        // POST: CropCycle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CropCycleID,CropCycleStartDate,CropCycleEndDate,CropCycleDescr")] CropCycle cropCycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cropCycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cropCycle);
        }

        // GET: CropCycle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CropCycle cropCycle = db.CropCycles.Find(id);
            if (cropCycle == null)
            {
                return HttpNotFound();
            }
            return View(cropCycle);
        }

        // POST: CropCycle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CropCycle cropCycle = db.CropCycles.Find(id);
            db.CropCycles.Remove(cropCycle);
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
