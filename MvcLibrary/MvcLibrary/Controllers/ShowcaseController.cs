using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
using MvcLibrary.Models.MyClasses;
namespace MvcLibrary.Controllers
{
    public class ShowcaseController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: Showcase
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.BooksValue = db.Books.ToList();
            cs.AboutValue = db.Abouts.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}