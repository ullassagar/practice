using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            user.UserID = Convert.ToInt32(reader["UserID"]);
            user.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            user.EmployeeNo = Convert.ToString(reader["EmployeeNo"]);
            user.UserName = Convert.ToString(reader["UserName"]);
            user.EmployeeName = Convert.ToString(reader["EmployeeName"]);
            user.Password = Convert.ToString(reader["Password"]);
            user.EmployeeEmailID = Convert.ToString(reader["EmployeeEmailID"]);
            user.RoleID = Convert.ToInt32(reader["RoleID"]);
            user.RoleName = Convert.ToString(reader["RoleName"]);
            return user;
        }

    }
}
