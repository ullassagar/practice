using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using Indpro.Attendance.Utility;

namespace Indpro.Attendance.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public string Password { get; set; }
        public string EmployeeEmailID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public static User Load(IDataReader reader)
        {
            User user = new User();
            user.UserID = DbHelper.ConvertToInt32(reader["UserID"]);
            user.EmployeeID = DbHelper.ConvertToInt32(reader["EmployeeID"]);
            user.EmployeeNo = DbHelper.ConvertToString(reader["EmployeeNo"]);
            user.UserName = DbHelper.ConvertToString(reader["UserName"]);
            user.EmployeeName = DbHelper.ConvertToString(reader["EmployeeName"]);
            user.Password = DbHelper.ConvertToString(reader["Password"]);
            user.Password = Decrypt(DbHelper.ConvertToString(reader["Password"]));
            user.EmployeeEmailID = DbHelper.ConvertToString(reader["EmployeeEmailID"]);
            user.RoleID = DbHelper.ConvertToInt32(reader["RoleID"]);
            user.RoleName = DbHelper.ConvertToString(reader["RoleName"]);
            return user;
        }

        private static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }

       
    
}
