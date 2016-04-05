using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSite.Models;
using BookSite.ViewModel;

namespace BookSite.Controllers
{
    public class HomeController : Controller
    {
        private Database2Entities db = new Database2Entities();
        public ActionResult Index()
        {
            return View(db.Book.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "User Number";
            IQueryable<UserGroup> data = from user in db.User
                                    group user by user.Admin into userGroup
               select new UserGroup()
               {
                   User = (int)userGroup.Key,
                   UserCount = userGroup.Count()
               };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Book Number";
            IQueryable<BookGroup> data = from book in db.Book
                                         group book by book.Course into bookGroup
                                         select new BookGroup()
                                         {
                                             Type = bookGroup.Key,
                                             BookCount = bookGroup.Count()
                                         };
            return View(data.ToList());
        }
    }
}