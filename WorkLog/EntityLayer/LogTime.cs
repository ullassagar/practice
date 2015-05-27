using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Entity
{
    public class LogTime
    {
        public int LogTimeID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LoggedTime { get; set; }
        public int LogTypeID { get; set; }
        public bool IsIn { get; set; }

        public static LogTime Load(IDataReader reader)
        {
            LogTime logtime = new LogTime();
            logtime.LogTimeID = Convert.ToInt32(reader["LogTimeID"]);
            logtime.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            logtime.LoggedTime = Convert.ToDateTime(reader["EmployeeID"]);
            logtime.LogTypeID = Convert.ToInt32(reader["LogTypeID"]);
            logtime.IsIn = Convert.ToBoolean(reader["IsIn"]);

            return logtime;
        }
    }
    
}

   
