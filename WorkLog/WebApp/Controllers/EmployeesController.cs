using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.Entity;
using Indpro.Attendance.WebApp.Models;
using WorkLog.Utilities;

namespace Indpro.Attendance.WebApp.Controllers
{
    [AuthorizeMember]
    public class EmployeesController : Controller
    {
        public ViewResult Index(int id = 0)
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

            var empModel = EmployeeModelMapper.MapToEmployeeModel(employee);
            return View("NewEmployee", empModel);
        }

        public ActionResult NewEmployee()
        {
            EmployeeModel u = new EmployeeModel();
            return View(u);
        }

        public ActionResult Edit(int id = 0)
        {
            Employee employee = EmployeeHandler.GetEmployee(id);

            var employeeModel = EmployeeModelMapper.MapToEmployeeModel(employee);

            return View(employeeModel);
        }

        public ActionResult Update(EmployeeModel model)
        {
            try
            {
                Employee employee = EmployeeModelMapper.MapToEmployee(model);
                EmployeeHandler.Update(employee);
            }
            catch(Exception ex)
            {
                model.Error = ex.Message;
                return View("Edit", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            EmployeeHandler.Delete(id);

            return RedirectToAction("Index"); 
        }
    }
}