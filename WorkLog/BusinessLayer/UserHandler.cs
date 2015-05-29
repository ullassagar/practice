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

            var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
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
            var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
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

        public static User GetUserByUserNamePassword(string username, string password)
        {
            User user = null;
            var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
                                    FROM IP_User U
                                    join IP_UserInRole UR on U.UserID=UR.UserID
                                    join IP_Roles R on UR.RoleID=R.RoleID
                                    join IP_Employee E on U.EmployeeID=E.EmployeeID
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
            var sql = string.Format(@"INSERT INTO IP_User (EmployeeID, UserName, Password)
                                     VALUES({0},'{1}','{2}'); SELECT @@IDENTITY;", user.EmployeeID, user.UserName, user.Password);

            var userId = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));

            sql = string.Format(@"INSERT INTO IP_UserInRole (UserId, RoleId)
                                     VALUES({0}, {1})", userId, user.RoleID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Update(User user)
        {
            var sql = string.Format("UPDATE IP_User  SET UserName='{0}', Password='{1}' where UserID={2}", user.UserName, user.Password, user.UserID);

           
           SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

        }

        public static void Delete(int id)
        {
            var sql = string.Format(@"Delete from IP_User  where UserID={0}", id);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static Dictionary<int, string> GetRoles()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();

            var sql = string.Format(@"SELECT RoleID, RoleName FROM IP_Roles;");
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    roles.Add(Convert.ToInt32(reader["RoleId"]), reader["RoleName"].ToString());
                }
            }
            return roles;
        }
    }
}



