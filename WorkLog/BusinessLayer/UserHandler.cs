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

            var sql = "SELECT UserID,UserName,UserPassword,EmployeeID FROM IndproAttendance.dbo.IP_User";
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
            var sql = string.Format(@"SELECT UserID,UserName,UserPassword,EmployeeID FROM IndproAttendance.dbo.IP_User
                                    Where UserId={0}", UserId);

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    user = User.Load(reader);
                }
            }
            return user;
        }
    }
}



      