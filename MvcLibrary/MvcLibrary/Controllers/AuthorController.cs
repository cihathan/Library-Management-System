using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        public ActionResult Index()
        {
            var values=db.Author.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        public ActionResult AddAuthor(Author author)
        {
            db.Author.Add(author);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.Author.Find(id);
            db.Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetAuthor(int id)
        {
            var author = db.Author.Find(id);
            return View("GetAuthor", author);
        }
        public ActionResult UpdateAuthor(Author a)
        {
            var author = db.Author.Find(a.ID);
            author.Name = a.Name;
            author.LastName = a.LastName;
            author.Details = a.Details;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}