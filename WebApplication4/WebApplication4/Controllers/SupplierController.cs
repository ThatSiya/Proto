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
    public class SupplierController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        public ActionResult ActionPage()
        {
            return View();
        }

        // GET: Supplier
        public ActionResult Index(string suppliername,string search, int? page)
        {
            SupplierIndexViewModel viewModel = new SupplierIndexViewModel();
            //select suppliers
            var suppliers = db.Suppliers.Include(s => s.Orders);
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
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,Address,Surburb,City,Country,Province,SupplierEmailAddress,SupplierPhoneNum,SupplierCellNum")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }
        // GET: Order/Create
        public ActionResult PlaceOrder()
        {
            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName");
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusDescr");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder([Bind(Include = "OrderNum,OrderDate,OrderItemPrice,SupplierID,UserID,FarmID,OrderStatusID,OrderItem")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");

                //TODO: Send Email to Supplier
            }

            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName", order.FarmID);
            ViewBag.OrderStatusID = new SelectList(db.OrderStatus, "OrderStatusID", "OrderStatusDescr", order.OrderStatusID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", order.SupplierID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", order.UserID);
            return View(order);
        }
        // GET: Order
        public ActionResult SupplierOrder()
        {
            var orders = db.Orders.Include(o => o.Farm).Include(o => o.OrderStatu).Include(o => o.Supplier).Include(o => o.User);
            return View(orders.ToList());
        }
        // GET: Order/Details/5
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
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
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,Address,Surburb,City,Country,Province,SupplierEmailAddress,SupplierPhoneNum,SupplierCellNum")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
