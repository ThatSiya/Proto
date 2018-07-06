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
    public class SiloController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Silo
        public ActionResult Index()
        {
            return View(db.Silos.ToList());
        }

        // GET: Silo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Silo silo = db.Silos.Find(id);
            if (silo == null)
            {
                return HttpNotFound();
            }
            return View(silo);
        }

        // GET: Silo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Silo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiloID,SiloDescr,SiloCapacity,SiloRentalFeePA,SiloStatus")] Silo silo)
        {
            if (ModelState.IsValid)
            {
                db.Silos.Add(silo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(silo);
        }

        // GET: HarvestSale/Create
        public ActionResult CreateHarvestSale()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");
            return View();
        }

        // POST: HarvestSale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHarvestSale([Bind(Include = "SaleID,SaleDate,SaleQty,SaleAmnt,CustomerID,PurchaseAgreement")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", sale.CustomerID);
            return View(sale);
        }
        // GET: Silo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Silo silo = db.Silos.Find(id);
            if (silo == null)
            {
                return HttpNotFound();
            }
            return View(silo);
        }

        // POST: Silo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiloID,SiloDescr,SiloCapacity,SiloRentalFeePA,SiloStatus")] Silo silo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(silo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(silo);
        }

        // GET: Silo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Silo silo = db.Silos.Find(id);
            if (silo == null)
            {
                return HttpNotFound();
            }
            return View(silo);
        }

        // POST: Silo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Silo silo = db.Silos.Find(id);
            db.Silos.Remove(silo);
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
