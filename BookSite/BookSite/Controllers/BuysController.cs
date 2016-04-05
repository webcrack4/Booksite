using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookSite.Models;

namespace BookSite.Controllers
{
    public class BuysController : Controller
    {
        private Database2Entities db = new Database2Entities();

        // GET: Buys
        public ActionResult Index()
        {
            var buy = db.Buy.Include(b => b.User);
           
            return View(buy.ToList());
        }

        // GET: Buys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buy.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // GET: Buys/Create
        public ActionResult Create()
        {
            ViewBag.UID = new SelectList(db.User, "UID", "FirstName");
            return View();
        }

        // POST: Buys/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuyID,Title,Date,ExpectPrice,TradeOrBuy,UID")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                db.Buy.Add(buy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UID = new SelectList(db.User, "UID", "FirstName", buy.UID);
            return View(buy);
        }

        // GET: Buys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buy.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            ViewBag.UID = new SelectList(db.User, "UID", "FirstName", buy.UID);
            return View(buy);
        }

        // POST: Buys/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyID,Title,Date,ExpectPrice,TradeOrBuy,UID")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UID = new SelectList(db.User, "UID", "FirstName", buy.UID);
            return View(buy);
        }

        // GET: Buys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buy.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // POST: Buys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buy buy = db.Buy.Find(id);
            db.Buy.Remove(buy);
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
