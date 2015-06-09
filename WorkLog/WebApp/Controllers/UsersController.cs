using System;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Models;
using Indpro.Attendance.WebApp.Utilities;

namespace Indpro.Attendance.WebApp.Controllers
{
    [AuthorizeMember]
    public class UsersController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            var model = new UserIndexModel();
            if (id > 0)
            {
                var usr = UserHandler.GetUser(id);
                var usrModel = UserModelIMapper.MapToUserModel(usr);
                model.List.Add(usrModel);
            }
            else
            {
                var usrList = UserHandler.GetAllUser();
                foreach (var usr in usrList)
                {
                    var usrModel = UserModelIMapper.MapToUserModel(usr);
                    model.List.Add(usrModel);
                }
            }
            return View(model);
        }

        public ActionResult Add(UserModel model)
        {
            try
            {
                var user = UserModelIMapper.MapToUser(model);
                UserHandler.Add(user);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Add", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult NewUser()
        {
            var u = new UserModel();
            return View(u);
        }

        public ActionResult Edit(int id = 0)
        {
            var user = UserHandler.GetUser(id);

            var usermodel = UserModelIMapper.MapToUserModel(user);

            return View(usermodel);
        }

        public ActionResult Update(UserModel model)
        {
            try
            {
                var user = UserModelIMapper.MapToUser(model);

                UserHandler.Update(user);
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