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
        //public ActionResult LogTiming(LogModel model, string command)
        // {
        //    var log = new LogTime();

        //    if(command=="In")
        //    {
        //        log.IsInTime=true;
        //    }

        //    else
        //    {
        //        log.IsInTime=false;
        //    }

        //    log.LoggedTime=DateTime.Now; 

        //    var user=(User) Session[Contanstants.LoggedInUserName];
        //    log.EmployeeID=user.EmployeeID;
        //    LogTimeHandler.Add(log);
        // }


        public ActionResult Index()
        {
            var model = new LogModel();
            return View(model);
        }

        public ActionResult Add(LogModel model)
        {
            return null;
        }

        public ActionResult NewLogTiming()
        {
            return null;
        }

    }
}