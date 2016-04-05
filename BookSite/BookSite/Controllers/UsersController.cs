using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookSite.Models;
using BookSite.ViewModel;

namespace BookSite.Controllers
{
    public class UsersController : Controller
    {
        private Database2Entities db = new Database2Entities();

        // GET: Users
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var user = from s in db.User
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    user = user.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    user = user.OrderBy(s => s.BirthDate);
                    break;
                case "date_desc":
                    user = user.OrderByDescending(s => s.BirthDate);
                    break;
                default:
                    user = user.OrderBy(s => s.LastName);
                    break;
            }
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,FirstName,LastName,Address,BirthDate,Admin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,FirstName,LastName,Address,BirthDate,Admin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Message() {
            ViewBag.Message = "Message Number";
            IQueryable<MessageGroup> data = from message in db.Message join user in db.User on message.UID equals user.UID
                                         group message.UID  by user.FirstName into userGroup
                                            select new MessageGroup()
                                         {
                                             UserName = userGroup.Key,
                                             MessageCount = userGroup.Count()
                                         };
            return View(data.ToList());
        }

        public ActionResult Book()
        {
            ViewBag.Message = "Sold Book Number";
            IQueryable<soldGroup> data = from book in db.Book join user in db.User on book.UID equals user.UID
                                            group book.UID by user.FirstName into userGroup
                                            select new soldGroup()
                                            {
                                                UserName = userGroup.Key,
                                                BookCount = userGroup.Count()
                                            };
            return View(data.ToList());
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
