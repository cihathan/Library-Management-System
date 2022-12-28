using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        devrimme_cihatEntities db = new devrimme_cihatEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var values = db.Employee.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEmployee");
            }
            db.Employee.Add(employee);
            db.SaveChanges();
            return View();
        }
    }
}