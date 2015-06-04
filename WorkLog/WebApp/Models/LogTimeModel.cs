using Indpro.Attendance.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Indpro.Attendance.WebApp.Models
{
    public class LogTimeModel
    {
        public int LogTimeID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LoggedTime { get; set; }

        [Required(ErrorMessage="Select LogType")]
        public LogType LogType { get; set; }
        public bool IsInTime { get; set; }

        public string Error { get; set; }
    }

    public class LogTimeModelIMapper
    {
        public static LogTimeModel MapToLogTimeModel(LogTime logtime)
        {
            LogTimeModel model = new LogTimeModel();

            if (logtime != null)
            {
                model.LogTimeID = logtime.LogTimeID;
                model.EmployeeID = logtime.EmployeeID;
                model.EmployeeNo = logtime.EmployeeNo;
                model.LoggedTime = logtime.LoggedTime ;
                model.LogType = logtime.LogType;
                model.IsInTime = logtime.IsInTime;
            }
            return model;
        }

        public static LogTime MapToLogTime(LogTimeModel model)
        {
            LogTime logtime = new LogTime(); 

            if(model!=null)
            {
                logtime.LogTimeID = model.LogTimeID;
                logtime.EmployeeID = model.EmployeeID;
                logtime.EmployeeNo = model.EmployeeNo;
                logtime.LoggedTime = model.LoggedTime;
                logtime.LogType = model.LogType;
                logtime.IsInTime = model.IsInTime;

            }
            return logtime;
        }
    }
}