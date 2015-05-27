using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using WebApp.Models;
using WorkLog.Utilities;

namespace WorkLog.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            Entity.User user = UserHandler.GetUserByUserNamePassword(model.UserName, model.Password);
            if (user != null)
            {
                Session[Contanstants.LoggedInUserName] = user;
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ViewBag.Message = "Username and password does not match.";
                return View();    
            }
        }

        public ActionResult LogOut()
        {
            Session[Contanstants.LoggedInUserName] = null;
            return RedirectToAction("Login");
        }
    }
}
