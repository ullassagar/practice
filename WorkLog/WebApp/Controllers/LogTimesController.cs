using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BusinessLayer;
using System.Web.UI.WebControls;
using WorkLog.Utilities;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AuthorizeMember]
    public class LogTimesController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            var model = new List<LogTimeModel>();
            if (id > 0)
            {
                var logtme = LogTimeHandler.GetLogTime(id);
                var logtmeModel = LogTimeModelIMapper.MapToLogTimeModel(logtme);
                model.Add(logtmeModel);
            }
            else
            {
                var logtmeList = LogTimeHandler.GetAllLogTime();
                foreach (var logtme in logtmeList)
                {
                    var logtmeModel = LogTimeModelIMapper.MapToLogTimeModel(logtme);
                    model.Add(logtmeModel);
                }
            }

            return View(model);
        }
        
        public ActionResult Add(LogTimeModel model)
        {
            var logtime = LogTimeModelIMapper.MapToLogTime(model);
            LogTimeHandler.Add(logtime);
            return RedirectToAction("Index");
        }

        public ActionResult NewLogTime()
        {
            LogTimeModel l = new LogTimeModel();
            return View(l);
        }

        public ActionResult Edit(int id = 0)
        {
            LogTime logtime = LogTimeHandler.GetLogTime(id);

            var logtimeModel = LogTimeModelIMapper.MapToLogTimeModel(logtime);

            return View(logtimeModel);
        }

        public ActionResult Update(LogTimeModel model)
        {
            LogTime logtime = LogTimeModelIMapper.MapToLogTime(model);

            LogTimeHandler.Update(logtime);

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id=0)
        {
            LogTimeHandler.Delete(id);

            return RedirectToAction("Index");
 
        }
    }
}