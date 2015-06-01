using Indpro.Attendance.Business;
using Indpro.Attendance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp.Models;
using WorkLog.Utilities;

namespace WebApp.Controllers
{
    [AuthorizeMember]
    public class UsersController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            var model = new List<UserModel>();
            if (id > 0)
            {
                var usr = UserHandler.GetUser(id);
                var usrModel = UserModelIMapper.MapToUserModel(usr);
                model.Add(usrModel);
            }
            else
            {
                var usrList = UserHandler.GetAllUser();
                foreach (var usr in usrList)
                {
                    var usrModel = UserModelIMapper.MapToUserModel(usr);
                    model.Add(usrModel);
                }
            }
            return View(model);
        }

        public ActionResult Add(UserModel model)
        {
            var user = UserModelIMapper.MapToUser(model);
            UserHandler.Add(user);

            return RedirectToAction("Index");
        }

        public ActionResult NewUser()
        {
            UserModel u = new UserModel();
            return View(u);
        }

        public ActionResult Edit(int id = 0)
        {
            User user = UserHandler.GetUser(id);

            var usermodel = UserModelIMapper.MapToUserModel(user);

            return View(usermodel);
        }

        public ActionResult Update(UserModel model)
        {
            User user = UserModelIMapper.MapToUser(model);

            UserHandler.Update(user);

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id = 0)
        {
            UserHandler.Delete(id);

             return RedirectToAction("Index");

        }
    }
}
