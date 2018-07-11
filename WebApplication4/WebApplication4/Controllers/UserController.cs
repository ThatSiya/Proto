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
    public class UserController : Controller
    {
        private FarmDbContext db = new FarmDbContext();

        // GET: User
        public ActionResult Index(string search, int? page)
        {
            UserIndexViewModel viewModel = new UserIndexViewModel();
            var users = db.Users.Include(c => c.UserAccessLevel);
            if (!String.IsNullOrEmpty(search))
            {
                users = db.Users.Where(c => c.UserFName.Contains(search) ||
                c.UserLName.Contains(search) || c.UserName.Contains(search));
                //ViewBag.Search = search;
                viewModel.Search = search;
            }
            //sort results
            users = users.OrderBy(i => i.UserID);
            //Paging:
            const int PageItems = 5;
            int currentPage = (page ?? 1);
            viewModel.Users = users.ToPagedList(currentPage, PageItems);
            return View(viewModel);
            //var users = db.Users.Include(u => u.UserAccessLevel);
            //return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.UserAccessLevelID = new SelectList(db.UserAccessLevels, "UserAccessLevelID", "UserAccessLevelDescr");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserEmailAddress,UserPassword,UserContractNum,UserFName,UserLName,UserIDNum,UserAccessLevelID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserAccessLevelID = new SelectList(db.UserAccessLevels, "UserAccessLevelID", "UserAccessLevelDescr", user.UserAccessLevelID);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserAccessLevelID = new SelectList(db.UserAccessLevels, "UserAccessLevelID", "UserAccessLevelDescr", user.UserAccessLevelID);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserEmailAddress,UserPassword,UserContractNum,UserFName,UserLName,UserIDNum,UserAccessLevelID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserAccessLevelID = new SelectList(db.UserAccessLevels, "UserAccessLevelID", "UserAccessLevelDescr", user.UserAccessLevelID);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
