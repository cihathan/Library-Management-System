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
        /* <---------------------!!!!!!!!!!!!!!!!!!!!!!---------------------> */
        // GET: Book
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        public ActionResult Index(string p)
        {
            var books = from b in db.Book select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(x => x.Name.Contains(p));
            }
            //var books = db.Book.ToList();
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categoryValue = (from i in db.Category.ToList() select new SelectListItem { Text = i.Name, Value = i.ID.ToString() }).ToList();
            ViewBag.cValue = categoryValue;
            List<SelectListItem> authorValue = (from i in db.Author.ToList() select new SelectListItem { Text = i.Name + ' ' + i.LastName, Value = i.ID.ToString() }).ToList();
            ViewBag.aValue = authorValue;
            return View();
        }
        /* <---------------------!!!!!!!!!!!!!!!!!!!!!!---------------------> */
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            var category = db.Category.Where(x => x.ID == book.Category1.ID).FirstOrDefault();
            var author = db.Author.Where(x => x.ID == book.Author1.ID).FirstOrDefault();
            book.Category1 = category;
            book.Author1 = author;
            db.Book.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            var book = db.Book.Find(id);
            List<SelectListItem> categoryValue = (from i in db.Category.ToList() select new SelectListItem { Text = i.Name, Value = i.ID.ToString() }).ToList();
            ViewBag.cValue = categoryValue;

            List<SelectListItem> authorValue = (from i in db.Author.ToList() select new SelectListItem { Text = i.Name + ' ' + i.LastName, Value = i.ID.ToString() }).ToList();
            ViewBag.aValue = authorValue;
            return View("GetBook", book);
        }

        /* <---------------------!!!!!!!!!!!!!!!!!!!!!!---------------------> */
        public ActionResult UpdateBook(Book b)
        {
            var book = db.Book.Find(b.ID);
            book.Name = b.Name;
            book.YearOfPublication = b.YearOfPublication;
            book.NumberOfPages = b.NumberOfPages;
            book.Publisher = b.Publisher;
            var category = db.Category.Where(x => x.ID == b.Category1.ID).FirstOrDefault();
            var author = db.Author.Where(x=>x.ID== b.Author1.ID).FirstOrDefault();
            book.Category = category.ID;
            book.Author = author.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}