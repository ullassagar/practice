using System;
using System.Web.Mvc;
using Indpro.Attendance.Business;
using Indpro.Attendance.WebApp.Areas.Admin.Models;

namespace Indpro.Attendance.WebApp.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
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

        public ActionResult Add()
        {
            var u = new EmployeeModel();
            return View(u);
        }

        [HttpPost]
        public ActionResult Add(EmployeeModel model)
        {
            var employee = EmployeeModelMapper.MapToEmployee(model);

            try
            {
                employee.IsActive = true;
                EmployeeHandler.Add(employee);
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                return View("Add", model);
            }

            var empModel = EmployeeModelMapper.MapToEmployeeModel(employee);
            return View("Add", empModel);
        }

        public ActionResult Edit(int id = 0)
        {
            var employee = EmployeeHandler.GetEmployee(id);

            var employeeModel = EmployeeModelMapper.MapToEmployeeModel(employee);

            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
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