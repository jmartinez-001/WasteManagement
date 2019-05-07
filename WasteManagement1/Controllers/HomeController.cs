using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasteManagement1.Models;

namespace WasteManagement1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {          
            db = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {            
                return View();            

        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Get to know us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out";

            return View();
        }
    }
}