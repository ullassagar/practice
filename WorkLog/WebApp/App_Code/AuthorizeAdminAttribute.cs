using System;
using System.Web;
using System.Web.Mvc;

namespace Indpro.Attendance.WebApp
{
    public static class Contanstants
    {
        public static string LoggedInUserName = "SessionLoggedInUserIn";
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[Contanstants.LoggedInUserName] == null)
            {
                return false;
            }
            return true;
        }
    }
}