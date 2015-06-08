using Indpro.Attendance.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Indpro.Attendance.WebApp.Models
{
    public class UserIndexModel : MasterModel
    {
        public List<UserModel> List { get; set; }

        public UserIndexModel()
        {
            Title = "Admin: User";
            ActiveModel = "User";
            List = new List<UserModel>();
        }
    }

    public class UserModel : MasterModel
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmailID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public string Error { get; set; }

        public UserModel()
        {
            Title = "Admin: User";
            ActiveModel = "User";
        }
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