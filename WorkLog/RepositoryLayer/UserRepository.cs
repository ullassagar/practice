using Indpro.Attendance.Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public static User GetAdminUser(string username, string password)
        {
            User user = null;
            var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password, E.EmployeeNo, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
                                    FROM IP_User U
                                    join IP_UserInRole UR on U.UserID=UR.UserID
                                    join IP_Roles R on UR.RoleID=R.RoleID 
                                    left join IP_Employee E on U.EmployeeID=E.EmployeeID
                                    WHERE UR.RoleId=1 AND UserName='{0}' AND Password='{1}'", username, Encrypt(password));

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    user = User.Load(reader);
                }
            }

            return user;
        }

        public static User GetEmployeeUser(string username, string password)
        {
            User user = null;
            var sql = string.Format(@"SELECT U.UserID, U.EmployeeID, U.UserName, U.Password,E.EmployeeNo, E.EmployeeName, E.EmployeeEmailID, R.RoleID, R.RoleName
                                    FROM IP_User U
                                    join IP_UserInRole UR on U.UserID=UR.UserID
                                    join IP_Roles R on UR.RoleID=R.RoleID 
                                    join IP_Employee E on U.EmployeeID=E.EmployeeID
                                    WHERE UR.RoleId=2 AND UserName='{0}' AND Password='{1}'", username, Encrypt(password));

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    user = User.Load(reader);
                }
            }

            return user;
        }

        public static string Add(User user)
        {
            var sql = string.Format("SELECT COUNT(*) FROM IP_User WHERE UserName='{0}';", user.UserName);

            var count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));
            if (count > 0)
            {
                return "Username already exists!!!";
            }

            sql = string.Format(@"INSERT INTO IP_User (EmployeeID, UserName, Password)
                                     VALUES({0},'{1}','{2}'); SELECT @@IDENTITY;", user.EmployeeID, user.UserName, Encrypt(user.Password));

            var userId = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));

            sql = string.Format(@"INSERT INTO IP_UserInRole (UserId, RoleId)
                                     VALUES({0}, {1})", userId, user.RoleID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

            return null;
        }

        public static string Update(User user)
        {
            var sql = string.Format("SELECT COUNT(*) FROM IP_User WHERE UserName='{0}' AND UserID!={1};", user.UserName,user.UserID);

            var count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));
            if (count > 0)
            {
                return "Username already exists!!!";
            }
             sql = string.Format("UPDATE IP_User SET UserName='{0}', Password='{1}' where UserID={2}", user.UserName, Encrypt(user.Password), user.UserID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

            sql = string.Format("UPDATE IP_UserInRole  SET RoleID={0} where UserID={1}", user.RoleID, user.UserID);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

            return null;
        }

        public static void Delete(int id)
        {
            var sql = string.Format(@"Delete from IP_UserInRole  where UserID={0}", id);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

            sql = string.Format(@"Delete from IP_User  where UserID={0}", id);
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

        public static Dictionary<int, string> GetEmployeeNos()
        {
            Dictionary<int, string> employeenos = new Dictionary<int, string>();

            var sql = @"SELECT EmployeeID, EmployeeNo 
                        FROM IP_Employee 
                        WHERE IsActive = 1
                        AND EmployeeID NOT IN(SELECT EmployeeID FROM IP_User WHERE EmployeeID IS NOT NULL);";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    employeenos.Add(Convert.ToInt32(reader["EmployeeID"]), reader["EmployeeNo"].ToString());
                }
            }

            return employeenos;
        }

        private static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



    }
}
