using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class GiveBookController : Controller
    {
        // GET: GiveBook
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GiveBook() {
            return View();
        }
    }
}