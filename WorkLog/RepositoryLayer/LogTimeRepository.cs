using Indpro.Attendance.Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indpro.Attendance.Repository
{
  public  class LogTimeRepository
    {
      public static List<LogTime> GetAllLogTime()
      {
          List<LogTime> loglist = new List<LogTime>();

          var sql = string.Format(@"SELECT IP_LogTime.LogTimeID,IP_LogTime.EmployeeID,IP_LogTime.LoggedTime,
                                    IP_LogTime.LogTypeID,IP_LogTime.IsInTime
                                    FROM IP_LogTime join IP_Employee on IP_LogTime.EmployeeID=IP_Employee.EmployeeID");

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              while (reader.Read())
              {
                  loglist.Add(LogTime.Load(reader));
              }
          }
          return loglist;
      }

      public static LogTime GetLogTime(int LogTimeID)
      {
          LogTime logtime = null;

          var sql = string.Format(@"SELECT IP_LogTime.LogTimeID,IP_LogTime.EmployeeID,IP_LogTime.LoggedTime,
                                    IP_LogTime.LogTypeID,IP_LogTime.IsInTime
                                    FROM IP_LogTime join IP_Employee on IP_LogTime.EmployeeID=IP_Employee.EmployeeID where IP_LogTime.LogTimeID={0}", LogTimeID);

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              while (reader.Read())
              {
                  logtime = LogTime.Load(reader);
              }
          }
          return logtime;
      }

      public static void Add(LogTime logtime)
      {
          var sql = string.Format(@"INSERT INTO IP_LogTime (EmployeeID ,LoggedTime ,LogTypeID ,IsInTime)
                                    VALUES({0},'{1}',{2},'{3}')", logtime.EmployeeID, logtime.LoggedTime,
              (int)logtime.LogType, logtime.IsInTime);

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }

      public static void Update(LogTime logtime)
      {
          var sql = string.Format(@"UPDATE IP_LogTime SET EmployeeID = {0},LoggedTime ='{1}',LogTypeID={2}, IsInTime='{3}'
                                      WHERE LogTimeID={4}", logtime.EmployeeID, logtime.LoggedTime, (int)logtime.LogType, logtime.IsInTime, logtime.LogTimeID);

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }

      public static void Delete(int id)
      {
          var sql = string.Format("DELETE FROM IP_LogTime  WHERE LogTimeID={0}", id);

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }
    }
}
