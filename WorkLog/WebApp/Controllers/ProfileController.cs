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
    [AuthorizeUser]
    public class ProfileController : Controller
    {
        public ViewResult Index()
        {
            var user = (User)Session[Constants.LoggedInUserName];
            var employee = EmployeeHandler.GetEmployee(user.EmployeeID);
            var profileModel = ProfileModelIMapper.MapToProfileModel(employee);
            return View(profileModel);
        }
        
        public ViewResult Edit()
        {
            var user = (User)Session[Constants.LoggedInUserName];
            var profile = EmployeeHandler.GetEmployee(user.EmployeeID);
            var profileModel = ProfileModelIMapper.MapToProfileModel(profile);
            return View(profileModel);
        }

        [HttpPost]
        public ActionResult Edit(ProfileModel model)
        {
            var profile = ProfileModelIMapper.Maptoprofile(model);
            EmployeeHandler.Update(profile);
            return RedirectToAction("Index");
           // return View("Index", model);
        }
    }
}
