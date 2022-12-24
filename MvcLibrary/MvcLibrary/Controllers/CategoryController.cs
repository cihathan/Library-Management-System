using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        public ActionResult Index()
        {
            var values = db.Category.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = db.Category.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var ctg = db.Category.Find(category.ID);
            ctg.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}