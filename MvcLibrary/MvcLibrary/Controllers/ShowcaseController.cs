using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        public ActionResult Index()
        {
            return View();
        }
    }
}