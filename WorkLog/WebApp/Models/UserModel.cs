using Entity;
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
        public string UserName { get; set; }
        public string Password { get; set; }
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
                model.UserName = user.UserName;
                model.Password = user.Password;
            }
            return model;
        }

        public static User MapToUser(UserModel model)
        {
            User user = new User();
            {
                user.UserID = model.UserID;
                user.EmployeeID = model.EmployeeID;
                user.UserName = model.UserName;
                user.Password = model.Password;
            }
            return user;
        }
    }
}