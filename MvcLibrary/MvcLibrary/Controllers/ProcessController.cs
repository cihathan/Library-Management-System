using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class ProcessController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: Process
        public ActionResult Index()
        {
            var values = db.Movements.Where(x => x.TransactionStatus == true).ToList();
            return View(values);
        }
    }
}