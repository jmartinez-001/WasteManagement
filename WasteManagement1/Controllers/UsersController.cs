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
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (isEmployeeUser())
                {
                    return RedirectToAction("Registration", "Employee");
                }
                else
                {
                    return RedirectToAction("Registrations", "Customer");

                }
            }
            else
            {
                return View();
            }

        }
        public Boolean isEmployeeUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Employee")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}