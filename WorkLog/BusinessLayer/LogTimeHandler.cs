﻿using System.ComponentModel.Design;
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

        public static void GetActiveLogTypes(int employeeId, DateTime dateTime, out LogType suggestedLogType, out List<LogType> activeTypes, out List<IsInTime> activeStatuses)
        {
            suggestedLogType = LogType.Work;
            activeTypes = new List<LogType>();
            activeStatuses = new List<IsInTime>();

            LogTime log = LogTimeRepository.GetEarlierLogTime(employeeId, dateTime);

            if (log == null)
            {
                suggestedLogType = LogType.Work;
                activeTypes.Add(LogType.Work);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Work && log.IsInTime == false)
            {
                suggestedLogType = LogType.Work;
                activeTypes.Add(LogType.Work);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Work && log.IsInTime == true)
            {
                suggestedLogType = LogType.Work;

                activeTypes.Add(LogType.Work);
                activeTypes.Add(LogType.Tea);
                activeTypes.Add(LogType.Lunch);
                activeTypes.Add(LogType.Others);

                activeStatuses.Add(IsInTime.False);
                return;
            }

            if (log.LogType == LogType.Tea && log.IsInTime == false)
            {
                suggestedLogType = LogType.Tea;
                activeTypes.Add(LogType.Tea);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Lunch && log.IsInTime == false)
            {
                suggestedLogType = LogType.Lunch;
                activeTypes.Add(LogType.Lunch);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if (log.LogType == LogType.Others && log.IsInTime == false)
            {
                suggestedLogType = LogType.Others;
                activeTypes.Add(LogType.Others);
                activeStatuses.Add(IsInTime.True);
                return;
            }

            if ((log.LogType == LogType.Tea || log.LogType == LogType.Lunch || log.LogType == LogType.Others) && log.IsInTime == true)
            {
                suggestedLogType = LogType.Work;

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

        public static Dictionary<int, string> GetAllEmployeeNos()
        {
            return LogTimeRepository.GetAllEmployeeNos();
        }
    }
}
