using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Indpro.Attendance.Entity
{
    public enum LogType
    {
        Work=1,
        Tea=2,
        Lunch=3,
        Others=4
    }

    public enum IsInTime
    {
        True = 1,
        False = 2
    }

    public class LogTime
    {
        public int LogTimeID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime LoggedTime { get; set; }
        public LogType LogType { get; set; }
        public bool IsInTime { get; set; }

        public static LogTime Load(IDataReader reader)
        {
            LogTime logtime = new LogTime();
            logtime.LogTimeID = Convert.ToInt32(reader["LogTimeID"]);
            logtime.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            logtime.EmployeeNo = Convert.ToString(reader["EmployeeNo"]);
            logtime.LoggedTime = Convert.ToDateTime(reader["LoggedTime"]);
            logtime.LogType =(LogType) Convert.ToInt32(reader["LogTypeID"]);
            logtime.IsInTime = Convert.ToBoolean(reader["IsInTime"]);

            return logtime;
        }
    }
    
}

   
