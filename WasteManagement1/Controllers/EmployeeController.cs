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
            //List<Customer> pickups = new List<Customer>();
            //pickups = db.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();
            return View(employee);
        }

        // GET: Employee/Details/5
        public ActionResult Details(Customer customer)
        {
            CustomerViewModel displayCustomer = new CustomerViewModel();
            displayCustomer.FirstName = customer.FirstName;
            displayCustomer.LastName = customer.LastName;
            displayCustomer.Address = customer.Address;
            displayCustomer.City = customer.City;
            displayCustomer.State = customer.State;
            displayCustomer.ZipCode = customer.ZipCode;
            displayCustomer.Latitude = customer.Latitude;
            displayCustomer.Longitude = customer.Longitude;
            ViewBag.Id = customer.Id;
            displayCustomer.FirstName = customer.FirstName;
            return View(displayCustomer);
        }

        // GET: Employee/Create
        public ActionResult Registration()
        {
            string id = User.Identity.GetUserId();
            Employee employee = new Employee { UserId = id };
            db.Employees.Add(employee);
            db.SaveChanges();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Registration(Employee newEmployee)
        {
            string id = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(c => c.UserId == id).FirstOrDefault();

            try
            {
                employee.FirstName = newEmployee.FirstName;
                employee.LastName = newEmployee.LastName;
                employee.Address = newEmployee.Address;
                employee.City = newEmployee.City;
                employee.State = newEmployee.State;
                employee.ZipCode = newEmployee.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Index", "Employee");
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
