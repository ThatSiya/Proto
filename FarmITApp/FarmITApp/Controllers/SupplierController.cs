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
    public class SupplierController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: Supplier
        public ActionResult Index(string suppliername, string search, int? page)
        {
            SupplierIndexViewModel viewModel = new SupplierIndexViewModel();
            //select suppliers
            var suppliers = db.Suppliers.Include(s => s.Country).Include(s => s.Province);
            if (!String.IsNullOrEmpty(search))
            {
                suppliers = suppliers.Where(s => s.SupplierName.Contains(search));
                //ViewBag.Search = search; //store current search in ViewBag
                viewModel.Search = search;
            }

            if (!String.IsNullOrEmpty(suppliername))
            {
                suppliers = suppliers.Where(i => i.SupplierName == suppliername);
                viewModel.SupplierName = suppliername;
            }

            //sort results
            suppliers = suppliers.OrderBy(s => s.SupplierName);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Suppliers = suppliers.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescr");
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescr");
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,Address,Surburb,City,CountryID,ProvinceID,SupplierEmailAddress,SupplierPhoneNum,SupplierCellNum")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescr", supplier.CountryID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescr", supplier.ProvinceID);
            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescr", supplier.CountryID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescr", supplier.ProvinceID);
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,Address,Surburb,City,CountryID,ProvinceID,SupplierEmailAddress,SupplierPhoneNum,SupplierCellNum")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryDescr", supplier.CountryID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceDescr", supplier.ProvinceID);
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
