using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.ViewModels; //ref;
using PagedList; //adding paging

namespace WebApplication4.Controllers
{
    public class InventoryController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        public ActionResult ActionPage()
        {
            InventoryIndexViewModel viewModel = new InventoryIndexViewModel();
            return View(viewModel);
        }
        // GET: Inventory
        public ActionResult Index(string inventorytype,string search, int? page)
        {
            //instantiate new view model
            InventoryIndexViewModel viewModel = new InventoryIndexViewModel();

            //select inventories
            var inventories = db.Inventories.Include(i => i.InventoryType);

            //do search and save search string to view model
            if (!String.IsNullOrEmpty(search))
            {
                inventories = inventories.Where(i => i.InvDescr.Contains(search) || 
                //i.InvSIUnit.Contains(search) || 
                i.InventoryType.InvTypeDescr.Contains(search));
                //ViewBag.Search = search; //store current search in ViewBag
                viewModel.Search = search;
            }
            /*//generate list of distinct Types to be stored in ViewBag as a SelectList
            var inventorytypes = inventories.OrderBy(i => i.InventoryType.InvTypeDescr).Select(i =>
            i.InventoryType.InvTypeDescr).Distinct();*/

            //group search results into types and count how many items in each type
            viewModel.InvTypesWithCount = from matchingInventories in inventories
                                          where
                                          matchingInventories.InvTypeID != null
                                          group matchingInventories by
                                          matchingInventories.InventoryType.InvTypeDescr into
                                          InvTypeGroup
                                          select new InventoryTypesWithCount()
                                          {
                                              InvTypeDescr = InvTypeGroup.Key,
                                              InventoryCount = InvTypeGroup.Count()
                                          };

            if (!String.IsNullOrEmpty(inventorytype))
            {
                inventories = inventories.Where(i => i.InventoryType.InvTypeDescr == inventorytype);
                viewModel.InventoryType = inventorytype;
            }
            //ViewBag.InventoryType = new SelectList(inventorytypes);
            //Search is stored in the ViewBag to allow it to be reused when a user clicks on the: inventory type filter

            //viewModel.Inventories = inventories.OrderBy(c => c.InvDescr);

            //sort results
            inventories = inventories.OrderBy(i => i.InvDescr);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Inventories = inventories.ToPagedList(currentPage, PageItems);
            return View(viewModel);

            //return View(inventories.ToList());
            //return View(inventories.OrderBy(c => c.InvDescr).ToList()); Ordered list
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            ViewBag.InvTypeID = new SelectList(db.InventoryTypes, "InvTypeID", "InvTypeDescr");
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryID,InvDescr,InvQty,InvDatePurchased,InvCode,InvSIUnit,InvTypeID")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvTypeID = new SelectList(db.InventoryTypes, "InvTypeID", "InvTypeDescr", inventory.InvTypeID);
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvTypeID = new SelectList(db.InventoryTypes, "InvTypeID", "InvTypeDescr", inventory.InvTypeID);
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryID,InvDescr,InvQty,InvDatePurchased,InvCode,InvSIUnit,InvTypeID")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvTypeID = new SelectList(db.InventoryTypes, "InvTypeID", "InvTypeDescr", inventory.InvTypeID);
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
