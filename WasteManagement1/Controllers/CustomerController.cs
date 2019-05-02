using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement1.Models;

namespace WasteManagement1.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.UserId == id).FirstOrDefault();
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Registration()
        {
            string id = User.Identity.GetUserId();
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Registration(Customer newCustomer)
        {
           

            try
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Create
        public ActionResult Services()
        {
            Pickup newPickUp = new Pickup();
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.UserId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Services(Customer Customer, Pickup newPickup)
        {
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.UserId == id).FirstOrDefault();
            
            try
            {
                db.Pickups.Add(newPickup);
                db.SaveChanges();
                return RedirectToAction("Services");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Profile()
        {
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.UserId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Profile(Customer updatedCustomer)
        {
            string id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.UserId == id).FirstOrDefault();
            try
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Address = updatedCustomer.Address;
                customer.City = updatedCustomer.City;
                customer.State = updatedCustomer.State;
                customer.ZipCode = updatedCustomer.ZipCode;
                return RedirectToAction("Profile");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Customer/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
