using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            var model = new List<EmployeeModel>();
            if (id > 0)
            {
                var emp = EmployeeHandler.GetEmployee(id);
                var empModel = EmployeeModelMapper.MapToEmployeeModel(emp);
                model.Add(empModel);
            }
            else
            {
                var empList = EmployeeHandler.GetAllEmployee();
                foreach (var emp in empList)
                {
                    var empModel = EmployeeModelMapper.MapToEmployeeModel(emp);
                    model.Add(empModel);
                }
            }

            return View(model);
        }


        public ActionResult Add(EmployeeModel model)
        {
            var employee = EmployeeModelMapper.MapToEmployee(model);

             EmployeeHandler.Add(employee);
          


            return RedirectToAction("Index");
        }

        public ActionResult NewEmployee()
        {
            EmployeeModel u = new EmployeeModel();
            return View(u);
        }
    }
}