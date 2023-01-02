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
        // Bu controller ödünç kitap ve ödünç kitap iade işlemleri için kullanılmaktadır.
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: GiveBook
        public ActionResult Index()
        {
            var values = db.Movements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveBook()
        {
            return View();
        }

        // Ödünç kitap verme işlemleri için.
        [HttpPost]
        public ActionResult GiveBook(Movement p)
        {
            db.Movements.Add(p);
            db.SaveChanges();
            return View();
        }
        // Ödünç kitabın iade işlemleri için. 
        public ActionResult GetBook(int id)
        {
            var getBook = db.Movements.Find(id);
            return View("GetBook", getBook);
        }
        public ActionResult GetBookUpdate(Movement p)
        {
            var movement = db.Movements.Find(p.MovementID);
            // Üyenin kitabı teslim tarihi.
            movement.UserDeliveryDate = p.UserDeliveryDate;
            // İşlem durumu.
            movement.TransactionStatus = true;
            //movement.UserDeliveryDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}