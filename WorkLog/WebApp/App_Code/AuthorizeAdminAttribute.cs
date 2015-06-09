using System;
using System.Web;
using System.Web.Mvc;

namespace Indpro.Attendance.WebApp
{
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