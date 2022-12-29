using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class UserController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: User
        public ActionResult Index()
        {
            var values = db.Users.ToList();
            return View(values);
        }
    }
}