using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class UserAccessLevelController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: UserAccessLevel
        public ActionResult Index(string search, int? page)
        {
            UserAccessLevelIndexViewModel viewModel = new UserAccessLevelIndexViewModel();
            var useraccesslvls = db.UserAccessLevels.Include(c => c.Users);
            if (!String.IsNullOrEmpty(search))
            {
                useraccesslvls = db.UserAccessLevels.Where(c => c.UserAccessLevelDescr.Contains(search));
                //ViewBag.Search = search;
                viewModel.Search = search;
            }
            //sort results
            useraccesslvls = useraccesslvls.OrderBy(i => i.UserAccessLevelID);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.UserAccessLevels = useraccesslvls.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: UserAccessLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccessLevel userAccessLevel = db.UserAccessLevels.Find(id);
            if (userAccessLevel == null)
            {
                return HttpNotFound();
            }
            return View(userAccessLevel);
        }

        // GET: UserAccessLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccessLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAccessLevelID,UserAccessLevelDescr")] UserAccessLevel userAccessLevel)
        {
            if (ModelState.IsValid)
            {
                db.UserAccessLevels.Add(userAccessLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccessLevel);
        }

        // GET: UserAccessLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccessLevel userAccessLevel = db.UserAccessLevels.Find(id);
            if (userAccessLevel == null)
            {
                return HttpNotFound();
            }
            return View(userAccessLevel);
        }

        // POST: UserAccessLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAccessLevelID,UserAccessLevelDescr")] UserAccessLevel userAccessLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccessLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccessLevel);
        }

        // GET: UserAccessLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccessLevel userAccessLevel = db.UserAccessLevels.Find(id);
            if (userAccessLevel == null)
            {
                return HttpNotFound();
            }
            return View(userAccessLevel);
        }

        // POST: UserAccessLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccessLevel userAccessLevel = db.UserAccessLevels.Find(id);
            db.UserAccessLevels.Remove(userAccessLevel);
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
