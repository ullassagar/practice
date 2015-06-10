using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp.Models;

namespace Indpro.Attendance.WebApp.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /Log/
        public ActionResult Index()
        {
            var model = new LogModel();
            return View(model);
        }
	}
}