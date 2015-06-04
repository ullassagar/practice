using Indpro.Attendance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Indpro.Attendance.WebApp.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }

        [StringLength(100)]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "EmployeeName Should be in the Text Formate")]
        [Required(ErrorMessage = "EmployeeName Required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Need to specify Gender.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "EmployeeDesignation Required.")]
        public string EmployeeDesignation { get; set; }
        public string EmployeeQualification { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmployeeDOB { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        //[Range(typeof(Date),"1900-01-01","2015-01-01")]
        public DateTime EmployeeDOJ { get; set; }
        public string EmployeeImage { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMobileNo { get; set; }
        public string EmployeeSkypeID { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmailID { get; set; }

        public string Error { get; set; }
    }

    public class EmployeeModelMapper
    {
        public static EmployeeModel MapToEmployeeModel(Employee employee)
        {
            EmployeeModel model = new EmployeeModel();
            if (employee != null)
            {
                model.EmployeeID = employee.EmployeeID;
                model.EmployeeNo = employee.EmployeeNo;
                model.EmployeeName = employee.EmployeeName;
                model.Gender = employee.Gender;
                model.EmployeeDesignation = employee.EmployeeDesignation;
                model.EmployeeQualification = employee.EmployeeQualification;
                model.EmployeeDOB = employee.EmployeeDOB;
                model.EmployeeDOJ = employee.EmployeeDOJ;
                model.EmployeeImage = employee.EmployeeImage;
                model.EmployeeAddress = employee.EmployeeAddress;
                model.EmployeeMobileNo = employee.EmployeeMobileNo;
                model.EmployeeSkypeID = employee.EmployeeSkypeID;
                model.EmployeeEmailID = employee.EmployeeEmailID;
            }
            return model;
        }

        public static Employee MapToEmployee(EmployeeModel model)
        {
            Employee employee = new Employee();
            if (model != null)
            {
                employee.EmployeeID = model.EmployeeID;
                employee.EmployeeNo = model.EmployeeNo;
                employee.EmployeeName = model.EmployeeName;
                employee.Gender = model.Gender;
                employee.EmployeeDesignation = model.EmployeeDesignation;
                employee.EmployeeQualification = model.EmployeeQualification;
                employee.EmployeeDOB = model.EmployeeDOB;
                employee.EmployeeDOJ = model.EmployeeDOJ;
                employee.EmployeeImage = model.EmployeeImage;
                employee.EmployeeAddress = model.EmployeeAddress;
                employee.EmployeeMobileNo = model.EmployeeMobileNo;
                employee.EmployeeSkypeID = model.EmployeeSkypeID;
                employee.EmployeeEmailID = model.EmployeeEmailID;
            }
            return employee;
        }
    }
}