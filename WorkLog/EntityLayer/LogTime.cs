using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Entity
{
    public enum LogTypeID
    {
        Work=1,
        Tea=2,
        Lunch=3
    }

    public class LogTime
    {
        public int LogTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LoggedTime { get; set; }
        public LogTypeID LogTypeID { get; set; }
        public bool IsIn { get; set; }

        public static LogTime Load(IDataReader reader)
        {
            LogTime logtime = new LogTime();
            logtime.LogTimeID = Convert.ToInt32(reader["LogTimeID"]);
            logtime.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            logtime.LoggedTime = Convert.ToDateTime(reader["LoggedTime"]);
            logtime.LogTypeID =(LogTypeID) Convert.ToInt32(reader["LogTypeID"]);
            logtime.IsIn = Convert.ToBoolean(reader["IsIn"]);

            return logtime;
        }
    }
    
}

   
