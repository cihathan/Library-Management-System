using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Weather() 
        {
            return View();
        }

        public ActionResult WeatherCard() { 
            return View();
        }
        public ActionResult Gallery() { 
            return View();
        }
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file) {
        if(file.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/web2/pictures/"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
            }
        return RedirectToAction("Gallery");
        }
    }
}