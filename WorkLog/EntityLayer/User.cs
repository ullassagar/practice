using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static User Load(IDataReader reader)
        {
            User user = new User();
            user.UserID = Convert.ToInt32(reader["UserID"]);
            user.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            user.UserName = Convert.ToString(reader["UserName"]);
            user.Password = Convert.ToString(reader["UserPassword"]);

            return user;
        }

    }
}
