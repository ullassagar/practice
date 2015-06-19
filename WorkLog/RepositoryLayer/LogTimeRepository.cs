using Indpro.Attendance.Entity;
using Indpro.Attendance.Utility;
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

          var sql = string.Format(@"SELECT L.LogTimeID, L.EmployeeID, E.EmployeeNo, L.LoggedTime, L.LogTypeID, L.IsInTime
                                    FROM IP_LogTime L 
                                    join IP_Employee E on L.EmployeeID=E.EmployeeID");

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

          var sql = string.Format(@"SELECT L.LogTimeID, L.EmployeeID, E.EmployeeNo, L.LoggedTime, L.LogTypeID, L.IsInTime
                                    FROM IP_LogTime L
                                    join IP_Employee E on L.EmployeeID=E.EmployeeID where L.LogTimeID={0}", LogTimeID);

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              while (reader.Read())
              {
                  logtime = LogTime.Load(reader);
              }
          }
          return logtime;
      }

      public static LogTime GetEarlierLogTime(int EmployeeID, DateTime dt)
      {
          LogTime logTime = null;

          var sql = string.Format(@"SELECT TOP 1 L.LogTimeID, L.EmployeeID, E.EmployeeNo, L.Loggedtime, L.LogTypeID, L.IsInTime 
                                    FROM IP_logtime L join ip_Employee E ON L.Employeeid=E.Employeeid 
                                    WHERE  E.EmployeeID={0} AND L.LoggedTime<='{1}' ORDER BY L.LogTimeID DESC, L.LoggedTime DESC", EmployeeID, dt);

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              if (reader.Read())
              {
                  logTime = LogTime.Load(reader);
              }
          }

          return logTime;
      }

      public static List<LogTime> GetLogTimeList(int EmployeeID,DateTime dt)
      {
          List<LogTime> loglist=new List<LogTime>();

          var sql = string.Format(@"SELECT L.LogTimeID,L.EmployeeID, E.EmployeeNo, L.Loggedtime,L.LogTypeID ,L.IsInTime 
                                    FROM IP_logtime L join ip_Employee E ON L.Employeeid=E.Employeeid 
                                    WHERE  E.EmployeeID={0} AND Replace(Convert(Varchar, L.LoggedTime, 111),'/','-')='{1}' ",EmployeeID,dt.ToString("yyyy-MM-dd"));

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              while (reader.Read())
              {
                  loglist.Add(LogTime.Load(reader));
              }
          }

          return loglist;
      }

      public static void Add(LogTime logtime)
      {
          var sql = string.Format(@"INSERT INTO IP_LogTime (EmployeeID, LoggedTime, LogTypeID, IsInTime)
                                    VALUES({0}, '{1}', {2}, {3})", logtime.EmployeeID, DbHelper.ConvertToSqlDateTime(logtime.LoggedTime), (int)logtime.LogType, (logtime.IsInTime ? 1 : 0));

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }

      public static void Update(LogTime logtime)
      {
          var sql = string.Format(@"UPDATE IP_LogTime SET LoggedTime='{0}', LogTypeID={1}, IsInTime={2}
                                    WHERE LogTimeID={3}",
              DbHelper.ConvertToSqlDateTime(logtime.LoggedTime), (int)logtime.LogType, logtime.IsInTime, logtime.LogTimeID);

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }

      public static void Delete(int id)
      {
          var sql = string.Format("DELETE FROM IP_LogTime  WHERE LogTimeID={0}", id);

          SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
      }

      public static Dictionary<int, string> GetAllEmployeeNos()
      {
          Dictionary<int, string> allemployeenos = new Dictionary<int, string>();

          var sql = string.Format(@"SELECT EmployeeID, EmployeeNo 
                        FROM IP_Employee 
                        WHERE IsActive = 1");

          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
          {
              while (reader.Read())
              {
                  allemployeenos.Add(Convert.ToInt32(reader["EmployeeID"]), reader["EmployeeNo"].ToString());
              }
          }

          return allemployeenos;
      }
    }
}
