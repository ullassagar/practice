using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Areas.Admin.Models;

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
            var user = UserHandler.GetAdminUser(model.UserName, model.Password);
            if (user != null)
            {
                Session[Constants.LoggedInUserName] = user;
                return RedirectToAction("Index", "Employees", new { area = "Admin" });
            }

            ViewBag.Message = "No Access!! Invalid User for this module";
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(UserModel model)
        {
            var user = UserHandler.GetEmployeeUser(model.UserName, model.Password);
            if (user != null)
            {
                Session[Constants.LoggedInUserName] = user;
                return RedirectToAction("Index", "Log");
            }

            ViewBag.Message = "Username and password does not match.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session[Constants.LoggedInUserName] = null;
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}