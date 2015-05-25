using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLayer;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Index(int id=0)
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


   

    }
}
