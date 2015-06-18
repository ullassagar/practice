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
    public class LogController : Controller
    {
        public ActionResult Index(string logDate = null, string reportDate = null)
        {
            var model = new ProfileLogModel();
            model.LogDate = string.IsNullOrEmpty(reportDate) ? DateTime.Now : Convert.ToDateTime(reportDate);
            model.LogType = LogType.Work;
            model.LogListDate = string.IsNullOrEmpty(reportDate) ? DateTime.Now : Convert.ToDateTime(reportDate);
            // model.LogListDate=

            var user = (User)Session[Constants.LoggedInUserName];
            var logtmeList = LogTimeHandler.GetLogTimeList(user.EmployeeID, model.LogListDate);
            var profileloglist = ProfileLogMapper.MapToProfileLogDetailList(logtmeList);
            model.LogList = profileloglist;

            return View("Index", model);
        }

        public ActionResult Add(ProfileLogModel model, string command)
        {
            LogTime log = new LogTime();
            log.IsInTime = command == "In";
            log.LogType = model.LogType;
            log.LoggedTime = model.LogDate;

            var user = (User)Session[Constants.LoggedInUserName];
            log.EmployeeID = user.EmployeeID;

            LogTimeHandler.Add(log);
            return RedirectToAction("Index");
        }

    }
}