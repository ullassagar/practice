using System;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Models;
using Indpro.Attendance.WebApp.Utilities;

namespace Indpro.Attendance.WebApp.Controllers
{
    [AuthorizeMember]
    public class EmployeesController : Controller
    {
        public ViewResult Index(bool includeNonActive = false)
        {
            var model = new EmployeeIndexModel();
            model.IncludeNonActive = includeNonActive;

            var empList = EmployeeHandler.GetAllEmployee(includeNonActive);

            foreach (var emp in empList)
            {
                var empModel = EmployeeModelMapper.MapToEmployeeModel(emp);
                model.EmployeeList.Add(empModel);
            }

            return View(model);
        }

        public ActionResult Add(EmployeeModel model)
        {
            var employee = EmployeeModelMapper.MapToEmployee(model);

            try
            {
                EmployeeHandler.Add(employee);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("NewEmployee", model);
            }

            var empModel = EmployeeModelMapper.MapToEmployeeModel(employee);
            return View("NewEmployee", empModel);
        }

        public ActionResult NewEmployee()
        {
            var u = new EmployeeModel();
            return View(u);
        }

        public ActionResult Edit(int id = 0)
        {
            var employee = EmployeeHandler.GetEmployee(id);

            var employeeModel = EmployeeModelMapper.MapToEmployeeModel(employee);

            return View(employeeModel);
        }

        public ActionResult Update(EmployeeModel model)
        {
            try
            {
                var employee = EmployeeModelMapper.MapToEmployee(model);
                EmployeeHandler.Update(employee);
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
                EmployeeHandler.Delete(id);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}