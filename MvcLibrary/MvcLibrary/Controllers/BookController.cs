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
            var books = from b in db.Books select b;
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
            List<SelectListItem> categoryValue = (from i in db.Categories.ToList() select new SelectListItem { Text = i.Name, Value = i.CategoryID.ToString() }).ToList();
            ViewBag.cValue = categoryValue;
            List<SelectListItem> authorValue = (from i in db.Authors.ToList() select new SelectListItem { Text = i.Name + ' ' + i.LastName, Value = i.AuthorID.ToString() }).ToList();
            ViewBag.aValue = authorValue;
            return View();
        }
        /* <---------------------!!!!!!!!!!!!!!!!!!!!!!---------------------> */
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            var category = db.Categories.Where(x => x.CategoryID == book.Category.CategoryID).FirstOrDefault();
            var author = db.Authors.Where(x => x.AuthorID == book.Author.AuthorID).FirstOrDefault();
            book.Category = category;
            book.Author = author;
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            var book = db.Books.Find(id);
            List<SelectListItem> categoryValue = (from i in db.Categories.ToList() select new SelectListItem { Text = i.Name, Value = i.CategoryID.ToString() }).ToList();
            ViewBag.cValue = categoryValue;

            List<SelectListItem> authorValue = (from i in db.Authors.ToList() select new SelectListItem { Text = i.Name + ' ' + i.LastName, Value = i.AuthorID.ToString() }).ToList();
            ViewBag.aValue = authorValue;
            return View("GetBook", book);
        }

        /* <---------------------!!!!!!!!!!!!!!!!!!!!!!---------------------> */
        public ActionResult UpdateBook(Book b)
        {
            var book = db.Books.Find(b.BookID);
            book.Name = b.Name;
            book.YearOfPublication = b.YearOfPublication;
            book.NumberOfPages = b.NumberOfPages;
            book.Publisher = b.Publisher;
            var category = db.Categories.Where(x => x.CategoryID == b.Category.CategoryID).FirstOrDefault();
            var author = db.Authors.Where(x=>x.AuthorID == b.Author.AuthorID).FirstOrDefault();
            book.CategoryID = category.CategoryID;
            book.AuthorID = author.AuthorID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}