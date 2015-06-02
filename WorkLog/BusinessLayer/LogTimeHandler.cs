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
