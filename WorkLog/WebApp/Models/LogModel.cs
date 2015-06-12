using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp;
using Indpro.Attendance.Entity;
using System.ComponentModel.DataAnnotations;
using Indpro.Attendance.Business;

namespace Indpro.Attendance.WebApp.Models
{
    public class LogIndexModel : MasterModel
    {
        public List<LogModel> LogList { get; set; }

        public LogIndexModel()
        {
            Title = "Employee: Log";
            ActiveModel = "Log";
            LogList = new List<LogModel>();
        }
    }

    public class LogModel : MasterModel
    {
        public bool IsLoggedIn { get; set; }

        [Required(ErrorMessage = "Select LogType")]
        public LogType LogType { get; set; }

        public string Error { get; set; }

        public LogModel()
        {
            Title = "Employee:Log ";
            ActiveModel = "Log";
        }
    }

    public class LogModelIMapper
    {
        public static LogModel MapToLogModel(LogTime log)
        {
            LogModel model = new LogModel();
            if( log!=null)
            {
                model.IsLoggedIn = log.IsInTime;                
                model.LogType = log.LogType;
            }
            return model;
        }

        public static LogTime MapToLog(LogModel model)
        {
            LogTime log = new LogTime();

            if (model != null)
            {
                log.IsInTime = model.IsLoggedIn;
                log.LogType = model.LogType;
            }
            return log;
        }
    }

}