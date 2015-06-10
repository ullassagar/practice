using System.Web.Mvc;
using System.Web.Routing;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Areas.Admin.Models;
using Indpro.Attendance.WebApp;

namespace Indpro.Attendance.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(UserModel model)
        {
            var user = UserHandler.GetAdmin(model.UserName, model.Password); // rename Method as "GetAdmin"
            if (user != null)
            {
                Session[Contanstants.LoggedInUserName] = user;
                return RedirectToAction("Index", "Employees", new { area = "Admin" });
            }
            else
            {
                ViewBag.Message = "No Access!! Invalid User for this module";
            }

           // ViewBag.Message = "Username and password does not match.";
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(UserModel model)
        {
            var user = UserHandler.GetEmployee(model.UserID);//rename Method as "GetEmployee"
            if (user != null)
            {
                Session[Contanstants.LoggedInUserName] = user;
                return RedirectToAction("Index", "Log");
            }
            ViewBag.Message = "Username and password does not match.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session[Contanstants.LoggedInUserName] = null;
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}