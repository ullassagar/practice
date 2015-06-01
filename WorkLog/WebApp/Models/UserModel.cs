using Indpro.Attendance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UserModel
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
    }

    public class UserModelIMapper
    {
        public static UserModel MapToUserModel(User user)
        {
            UserModel model = new UserModel();
            if (user != null)
            {
                model.UserID = user.UserID;
                model.EmployeeID = user.EmployeeID;
                model.EmployeeNo = user.EmployeeNo;
                model.UserName = user.UserName;
                model.EmployeeName = user.EmployeeName;
                model.Password = user.Password;
                model.EmployeeEmailID = user.EmployeeEmailID;
                model.RoleID = user.RoleID;
                model.RoleName = user.RoleName;   
            }
            return model;
        }

        public static User MapToUser(UserModel model)
        {
            User user = new User();
            {
                user.UserID = model.UserID;
                user.EmployeeID = model.EmployeeID;
                user.EmployeeNo = model.EmployeeNo;
                user.UserName = model.UserName;
                user.EmployeeName = model.EmployeeName;
                user.Password = model.Password;
                user.EmployeeEmailID = model.EmployeeEmailID;
                user.RoleID = model.RoleID;
                user.RoleName = model.RoleName;   
            }
            return user;
        }
    }
}