using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
using PagedList;

namespace MvcLibrary.Controllers
{
    public class UserController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: User
        public ActionResult Index(int page = 1)
        {
            //var values = db.Users.ToList();
            var values = db.Users.ToList().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            db.Users.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUser(int id)
        {
            var user = db.Users.Find(id);
            return View("GetUser", user);
        }
        public ActionResult UpdateUser(User p)
        {
            var user = db.Users.Find(p.UsersID);
            user.Name = p.Name;
            user.LastName = p.LastName;
            user.Mail = p.Mail;
            user.UserName = p.UserName;
            user.Password = p.Password;
            user.School = p.School;
            user.Phone = p.Phone;
            user.Photo = p.Photo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}