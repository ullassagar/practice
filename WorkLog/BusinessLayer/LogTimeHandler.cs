using Indpro.Attendance.Entity;
using Indpro.Attendance.Repository;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indpro.Attendance.Business
{
    public class LogTimeHandler
    {
        public static List<LogTime> GetAllLogTime()
        {
            return LogTimeRepository.GetAllLogTime();
        }

        public static LogTime GetLogTime(int LogTimeID)
        {
            return LogTimeRepository.GetLogTime(LogTimeID);
        }

        public static List<LogTime> GetLogTimeList(int EmployeeID, DateTime dt)
        {
            return LogTimeRepository.GetLogTimeList(EmployeeID, dt);
        }

        public static void GetActiveLogTypes(int employeeId, DateTime dateTime, out List<LogType> activeTypes, out List<IsInTime> activeStatuses)
        {
            activeTypes = new List<LogType>();
            activeStatuses = new List<IsInTime>();

            LogTime log = LogTimeRepository.GetEarlierLogTime(employeeId, dateTime);

            if (log == null)
            {
                activeTypes.Add(LogType.Work);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Work && log.IsInTime == false)
            {
                activeTypes.Add(LogType.Work);
                activeStatuses.Add(IsInTime.True);
                return;
            } 
            
            if (log.LogType == LogType.Work && log.IsInTime == true)
            {
                activeTypes.Add(LogType.Work);
                activeTypes.Add(LogType.Tea);
                activeTypes.Add(LogType.Lunch);
                activeTypes.Add(LogType.Others);

                activeStatuses.Add(IsInTime.False);
                return;
            }

            if (log.LogType == LogType.Tea && log.IsInTime == false)
            {
                activeTypes.Add(LogType.Tea);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Lunch && log.IsInTime == false)
            {
                activeTypes.Add(LogType.Lunch);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Others && log.IsInTime == false)
            {
                activeTypes.Add(LogType.Others);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if ((log.LogType == LogType.Tea || log.LogType == LogType.Lunch || log.LogType == LogType.Others) && log.IsInTime == true)
            {
                activeTypes.Add(LogType.Work);
                activeTypes.Add(LogType.Tea);
                activeTypes.Add(LogType.Lunch);
                activeTypes.Add(LogType.Others);

                activeStatuses.Add(IsInTime.False);
                return;
            }
        }

        public static void Add(LogTime logtime)
        {
            LogTimeRepository.Add(logtime);
        }

        public static void Update(LogTime logtime)
        {
            LogTimeRepository.Update(logtime);
        }

        public static void Delete(int id)
        {
            LogTimeRepository.Delete(id);
        }
    }
}
