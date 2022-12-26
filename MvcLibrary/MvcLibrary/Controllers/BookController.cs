using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        public ActionResult Index()
        {
            var books = db.Book.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categoryValue = (from i in db.Category.ToList() select new SelectListItem { Text = i.Name, Value = i.ID.ToString() }).ToList();
            ViewBag.cValue = categoryValue;
            List<SelectListItem> authorValue = (from i in db.Author.ToList() select new SelectListItem { Text = i.Name + i.LastName, Value = i.Name.ToString() }).ToList();
            ViewBag.aValue = authorValue;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            return View();
        }
    }
}