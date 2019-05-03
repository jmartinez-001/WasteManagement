using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement1.Models;

namespace WasteManagement1.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db;
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Employee
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(c => c.UserId == id).FirstOrDefault();
            List<Customer> pickups = db.Customers.Where(c => c.ZipCode == employee.ZipCode && c.PickUpDay == DayOfWeek.Monday || c.ExtraPickUpDay == DateTime.Today).ToList();
            return View(pickups);
        }

        // GET: Employee/Details/5
        public ActionResult Details(Customer displayCustomer)
        {
            
            return View();
        }

        // GET: Employee/Create
        public ActionResult Registration()
        {
            string id = User.Identity.GetUserId();
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Registration(Employee newEmployee)
        {

            try
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
