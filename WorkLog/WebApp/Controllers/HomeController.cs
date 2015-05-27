using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkLog.Utilities;

namespace WebApp.Controllers
{
    [AuthorizeMember]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "WebApp";
            return View();
        }
    }
}