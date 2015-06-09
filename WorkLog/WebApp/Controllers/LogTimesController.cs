using System;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Models;
using Indpro.Attendance.WebApp.Utilities;

namespace Indpro.Attendance.WebApp.Controllers
{
    [AuthorizeMember]
    public class LogTimesController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            var model = new LogTimeIndexModel();
            if (id > 0)
            {
                var logtme = LogTimeHandler.GetLogTime(id);
                var logtmeModel = LogTimeModelIMapper.MapToLogTimeModel(logtme);
                model.List.Add(logtmeModel);
            }
            else
            {
                var logtmeList = LogTimeHandler.GetAllLogTime();
                foreach (var logtme in logtmeList)
                {
                    var logtmeModel = LogTimeModelIMapper.MapToLogTimeModel(logtme);
                    model.List.Add(logtmeModel);
                }
            }
            return View(model);
        }

        public ActionResult Add(LogTimeModel model)
        {
            try
            {
                var logtime = LogTimeModelIMapper.MapToLogTime(model);
                LogTimeHandler.Add(logtime);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Add", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult NewLogTime()
        {
            var l = new LogTimeModel();
            return View(l);
        }

        public ActionResult Edit(int id = 0)
        {
            var logtime = LogTimeHandler.GetLogTime(id);

            var logtimeModel = LogTimeModelIMapper.MapToLogTimeModel(logtime);

            return View(logtimeModel);
        }

        public ActionResult Update(LogTimeModel model)
        {
            try
            {
                var logtime = LogTimeModelIMapper.MapToLogTime(model);

                LogTimeHandler.Update(logtime);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            try
            {
                LogTimeHandler.Delete(id);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}