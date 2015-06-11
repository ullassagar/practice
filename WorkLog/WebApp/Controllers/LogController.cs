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
    public class LogController : Controller
    {
        public ActionResult Index()
        {
            var model = new LogModel();
            return View(model);
        }

        public ActionResult Add(LogModel model,string command)
        {
            LogTime log=new LogTime();
            log.IsInTime = command == "In";
            log.LogType = model.LogType;
            log.LoggedTime = DateTime.Now;

            var user = (User)Session[Constants.LoggedInUserName];
            log.EmployeeID = user.EmployeeID;
            
            LogTimeHandler.Add(log);
            return RedirectToAction("Index");
        }

        public ActionResult NewLogTiming()
        {
            return null;
        }

    }
}