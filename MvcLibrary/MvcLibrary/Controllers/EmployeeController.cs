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
            var values = db.Employees.ToList();
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
            db.Employees.Add(employee);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteEmployee (int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            return View("GetEmployee", employee);
        }
        public ActionResult UpdateEmployee(Employee p)
        {
            var employee = db.Employees.Find(p.EmployeeID);
            employee.Employee1 = p.Employee1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}