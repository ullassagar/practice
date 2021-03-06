﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Indpro.Attendance.Entity;
using System.Linq;
using System.Web;

namespace Indpro.Attendance.WebApp.Areas.Admin.Models
{
    public class EmployeeIndexModel : MasterModel
    {
        public bool IncludeNonActive { get; set; }
        public List<EmployeeModel> EmployeeList { get; set; }

        public EmployeeIndexModel()
        {
            Title = "Admin: Employee";
            ActiveModel = "Employee";

            IncludeNonActive = false;
            EmployeeList = new List<EmployeeModel>();
        }
    }

    public class EmployeeModel : MasterModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }

        [StringLength(100)]
       // [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Name Should be in the Text Formate")]
        [Required(ErrorMessage = "Name required.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Specify Gender.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Designation Required.")]
        public string EmployeeDesignation { get; set; }

        public string EmployeeQualification { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmployeeDOB { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of joining Required.")]
        public DateTime EmployeeDOJ { get; set; }

        public string EmployeeImage { get; set; }
        public string EmployeeAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string EmployeeMobileNo { get; set; }

        public string EmployeeSkypeID { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmailID { get; set; }

        public bool IsActive { get; set; }
        public string Error { get; set; }

        public EmployeeModel()
        {
            Title = "Admin: Employee";
            ActiveModel = "Employee";
        }
    }

    public class EmployeeModelMapper
    {
        public static EmployeeModel MapToEmployeeModel(Employee employee)
        {
            var model = new EmployeeModel();
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
                model.IsActive = employee.IsActive;
            }
            return model;
        }

        public static Employee MapToEmployee(EmployeeModel model)
        {
            var employee = new Employee();
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
                employee.IsActive = model.IsActive;
            }
            return employee;
        }
    }
}