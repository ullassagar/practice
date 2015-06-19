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
            LogType suggestedLogType;
            List<LogType> activeTypes;
            List<IsInTime> activeStatuses;
            var user = (User)Session[Constants.LoggedInUserName];

            var model = new ProfileLogModel();
            model.LogDate = string.IsNullOrEmpty(reportDate) ? DateTime.Now : Convert.ToDateTime(reportDate);
            
            LogTimeHandler.GetActiveLogTypes(user.EmployeeID, model.LogDate, out suggestedLogType, out activeTypes, out activeStatuses);
            model.LogType = suggestedLogType;
            model.ActiveTypes = activeTypes;
            model.ActiveStatuses = activeStatuses;
            model.LogListDate = string.IsNullOrEmpty(reportDate) ? DateTime.Now : Convert.ToDateTime(reportDate);

            var logtmeList = LogTimeHandler.GetLogTimeList(user.EmployeeID, model.LogListDate);
            var profileloglist = ProfileLogMapper.MapToProfileLogDetailList(logtmeList);
            model.LogList = profileloglist;

            return View("Index", model);
        }

        public ActionResult Add(ProfileLogModel model, string command)
        {
            LogTime log = new LogTime();
            log.IsInTime = command == "Click here to Login Time";
            log.LogType = model.LogType;
            log.LoggedTime = model.LogDate;

            var user = (User)Session[Constants.LoggedInUserName];
            log.EmployeeID = user.EmployeeID;

            LogTimeHandler.Add(log);
            return RedirectToAction("Index");
        }

    }
}