﻿using System;
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
            // Movement tablosundaki TransactionStatus, durumu false olanları getirir.
            var values = db.Movements.Where(x => x.TransactionStatus == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveBook()
        {
            return View();
        }

        // Ödünç kitap verme işlemleri için kullanılmıştır.
        [HttpPost]
        public ActionResult GiveBook(Movement p)
        {
            db.Movements.Add(p);
            db.SaveChanges();
            return View();
        }
        // Ödünç kitabın iade işlemleri için kullanılmıştır.  
        public ActionResult GetBook(int id)
        {
            var getBook = db.Movements.Find(id);
            DateTime d1 = DateTime.Parse(getBook.ReturnDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.value = d3.TotalDays;
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