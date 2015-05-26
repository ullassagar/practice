using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace BusinessLayer
{
    public class UserHandler
    {
        public static List<User> GetAllUser()
        {
            List<User> userList = new List<User>();

            var sql =string.Format( @"SELECT IP_User.UserID, IP_User.EmployeeID, IP_User.UserName, IP_Employee.EmployeeName,IP_User.Password, IP_Employee.EmployeeEmailID
                                    FROM IP_User join IP_Employee on IP_User.EmployeeID=IP_Employee.EmployeeID");
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    userList.Add(User.Load(reader));
                }
            }
            return userList;
        }

        public static User GetUser(int UserId)
        {
            User user = null;
            var sql = string.Format(@"SELECT  IP_User.UserID, IP_User.EmployeeID, IP_User.UserName, IP_Employee.EmployeeName,IP_User.Password, IP_Employee.EmployeeEmailID
                                    FROM IP_User join IP_Employee on IP_User.EmployeeID=IP_Employee.EmployeeID", UserId);

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    user = User.Load(reader);
                }
            }
            return user;
        }

        public static User GetUserByUserNamePassword(string username, string password)
        {
            User user = null;
            var sql = string.Format(@"SELECT  IP_User.UserID, IP_User.EmployeeID, IP_User.UserName, IP_Employee.EmployeeName,IP_User.Password, IP_Employee.EmployeeEmailID
                                    FROM IP_User join IP_Employee on IP_User.EmployeeID=IP_Employee.EmployeeID
                                    WHERE UserName='{0}' AND Password='{1}'", username, password);

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
            var sql = string.Format(@"INSERT INTO IndproAttendance.dbo.IP_User (EmployeeID,UserName,Password)
                                     VALUES({0},'{1}','{2}')",user.EmployeeID,user.UserName,user.Password);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

        }
    }
}



      