using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class GiveBookController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: GiveBook
        public ActionResult Index()
        {
            var values = db.Movement.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveBook() {
            return View();
        }
        [HttpPost]
        public ActionResult GiveBook(Movement p)
        {
            db.Movement.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}