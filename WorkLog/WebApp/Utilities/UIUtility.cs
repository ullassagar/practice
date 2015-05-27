using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkLog.Utilities
{
    public static class Contanstants
    {
        public static string LoggedInUserName = "SessionLoggedInUserIn";
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeMemberAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session[Contanstants.LoggedInUserName]==null)
            {
                return false;
            }
            return true;
        }

    }   
}