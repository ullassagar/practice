using System;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.Entity;

namespace Indpro.Attendance.WebApp
{
    public static class Constants
    {
        public static string LoggedInUserName = "SessionLoggedInUserIn";
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[Constants.LoggedInUserName] == null)
            {
                return false;
            }
            else
            {
                var user = (User)httpContext.Session[Constants.LoggedInUserName];
                return user.RoleName.ToLower() == "admin";
            }
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[Constants.LoggedInUserName] == null)
            {
                return false;
            }
            else
            {
                var user = (User)httpContext.Session[Constants.LoggedInUserName];
                return user.RoleName.ToLower() == "user";
            }
        }
    }
}