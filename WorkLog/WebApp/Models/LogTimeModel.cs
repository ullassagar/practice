using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkLog.Models
{
    public class LogTimeModel
    {
        public int LogTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LoggedTime { get; set; }
        public int LogTypeID { get; set; }
        public bool IsIn { get; set; }
    }

    public class LogTimeIMapper
    {
        public static LogTimeModel MapToLogTimeModel(LogTime logtime)
        {
            LogTimeModel model = new LogTimeModel();

            if (logtime != null)
            {
                model.LogTimeID = logtime.LogTimeID;
                model.EmployeeID = logtime.EmployeeID;
                model.LoggedTime = logtime.LoggedTime;
                model.LogTypeID = logtime.LogTypeID;
                model.IsIn = logtime.IsIn;
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
                logtime.LoggedTime = model.LoggedTime;
                logtime.LogTypeID = model.LogTypeID;
                logtime.IsIn= model.IsIn;

            }
            return logtime;
        }
    }
}