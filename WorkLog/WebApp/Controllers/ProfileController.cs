using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp.Models;
using Indpro.Attendance.Entity;
using Indpro.Attendance.Business;

namespace Indpro.Attendance.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            var user = (User)Session[Constants.LoggedInUserName];
            var employee = EmployeeHandler.GetEmployee(user.EmployeeID);
            var profileModel = ProfileModelIMapper.MapToProfileModel(employee);
            return View(profileModel);
        }
    }
}