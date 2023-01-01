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
            var values=db.Authors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        public ActionResult AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetAuthor(int id)
        {
            var author = db.Authors.Find(id);
            return View("GetAuthor", author);
        }
        public ActionResult UpdateAuthor(Author a)
        {
            var author = db.Authors.Find(a.AuthorID);
            author.Name = a.Name;
            author.LastName = a.LastName;
            author.Details = a.Details;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}