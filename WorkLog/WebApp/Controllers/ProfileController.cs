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
        public ActionResult Index(int id = 0)
        {
            var model = new ProfileModel();
            var profile = EmployeeHandler.GetEmployee(id);
            return View(model);
        }

    //    public ActionResult Add(ProfileModel model)
        //{
        //    Employee profile = new Employee();

        //    profile.EmployeeNo = model.EmployeeNo;
        //    profile.EmployeeName = model.Name;
        //    profile.Gender = model.Gender;
        //    profile.EmployeeDesignation = model.Designation;
        //    profile.EmployeeQualification = model.Qualification;
        //    profile.EmployeeDOB = model.Dateofbirth;
        //    profile.EmployeeDOJ = model.Dateofjoining;
        //    profile.EmployeeAddress = model.Address;
        //    profile.EmployeeMobileNo = model.MobileNo;
        //    profile.EmployeeSkypeID = model.SkypeID;
        //    profile.EmployeeEmailID = model.EmailID;

        //    var user = (User)Session[Contanstants.LoggedInUserName];
        //    profile.EmployeeID = user.EmployeeID;


        //    return RedirectToAction("Index");
        //}
    }
}