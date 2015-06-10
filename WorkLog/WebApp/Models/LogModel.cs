using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp;
using Indpro.Attendance.Entity;
using System.ComponentModel.DataAnnotations;

namespace Indpro.Attendance.WebApp.Models
{
    public class LogModel : MasterModel
    {
        public bool IsLoggedIn { get; set; }

        [Required(ErrorMessage = "Select LogType")]
        public LogType LogType { get; set; }

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
              //  model.IsLoggedIn = log.IsLoggedIn;                
                model.LogType = log.LogType;
               
            }

            return model;
        }
        public static LogTime MapToLog(LogModel model)
        {
            LogTime log = new LogTime();

            if (model != null)
            {
               // log.IsloggedIn = model.log;
               // log.IsLoggedIn = model.IsLoggedIn;
            }
            return log;
        }
    }

}