using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using Indpro.Attendance.Entity;

namespace Indpro.Attendance.Repository
{
   public class UserRepository
    {
       public static List<User> GetAllUser()
       {
           List<User> userList = new List<User>();

           var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password,E.EmployeeNo, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
                                    FROM IP_User U
                                    join IP_UserInRole UR on U.UserID=UR.UserID
                                    join IP_Roles R on UR.RoleID=R.RoleID
                                    join IP_Employee E on U.EmployeeID=E.EmployeeID");
           using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
           {
               while (reader.Read())
               {
                   userList.Add(User.Load(reader));
               }
           }
           return userList;
       }

       public static User GetUser(int UserID)
       {
           User user = null;
           var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password,E.EmployeeNo, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
                                    FROM IP_User U
                                    join IP_UserInRole UR on U.UserID=UR.UserID
                                    join IP_Roles R on UR.RoleID=R.RoleID
                                    join IP_Employee E on U.EmployeeID=E.EmployeeID where U.UserID={0}", UserID);

           using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
           {
               if (reader.Read())
               {
                   user = User.Load(reader);
               }
           }
           return user;
       }

       public static void Add(User user)
       {
           var sql = string.Format(@"INSERT INTO IP_User (EmployeeID, UserName, Password)
                                     VALUES({0},'{1}','{2}'); SELECT @@IDENTITY;", user.EmployeeID, user.UserName, user.Password);

           var userId = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));

           sql = string.Format(@"INSERT INTO IP_UserInRole (UserId, RoleId)
                                     VALUES({0}, {1})", userId, user.RoleID);

           SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
       }
    }
}
