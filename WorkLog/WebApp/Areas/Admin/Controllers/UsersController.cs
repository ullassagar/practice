using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Areas.Admin.Models;

namespace Indpro.Attendance.WebApp.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserIndexModel();
            var usrList = UserHandler.GetAllUser();

            foreach (var usr in usrList)
            {
                var usrModel = UserModelIMapper.MapToUserModel(usr);
                model.List.Add(usrModel);
            }

            return View(model);
        }

        public ActionResult Add()
        {
            var u = new UserModel();
            return View(u);
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            var errror = string.Empty;

            try
            {
                var user = UserModelIMapper.MapToUser(model);
                errror = UserHandler.Add(user);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Add", model);
            }

            if (!string.IsNullOrEmpty(errror))
            {
                model.Error = errror;
                return View("Add", model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            var user = UserHandler.GetUser(id);
            var usermodel = UserModelIMapper.MapToUserModel(user);

            return View(usermodel);
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            var errror = string.Empty;
            try
            {
                var user = UserModelIMapper.MapToUser(model);
                errror = UserHandler.Update(user);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Edit", model);
            }

            if (!string.IsNullOrEmpty(errror))
            {
                model.Error = errror;
                return View("Edit", model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            try
            {
                UserHandler.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}