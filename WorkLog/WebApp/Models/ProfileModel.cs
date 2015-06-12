using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp;
using Indpro.Attendance.Entity;
using System.ComponentModel.DataAnnotations;

namespace Indpro.Attendance.WebApp.Models
{
    public class EmployeeIndexModel : MasterModel
    {
        public List<ProfileModel> EmployeeList { get; set; }

        public EmployeeIndexModel()
        {
            Title = "Employee: Profile";
            ActiveModel = "Profile";

            EmployeeList = new List<ProfileModel>();
        }
    }


    public class ProfileModel:MasterModel
    {
        public int employeeId { get; set; }
        public string EmployeeNo { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Name required.")]
        public string Name { get; set; }

         [Required(ErrorMessage = "Specify Gender.")]
         public Gender Gender { get; set; }
         public string Designation { get; set; }
         public string Qualification { get; set; }

         [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime Dateofbirth { get; set; }

         public DateTime Dateofjoining { get; set; }
         public string Address { get; set; }
         public string MobileNo { get; set; }
         public string SkypeID { get; set; }
         public string EmailID { get; set; }

         public string Error { get; set; }

         public ProfileModel()
        {
            Title = "Employee:Profile ";
            ActiveModel = "Profile";
        }
    }

    public class ProfileModelIMapper
    {
        public static ProfileModel MapToProfileModel(Employee profile)
        {
            ProfileModel model = new ProfileModel();

            if (profile!=null)
            {
                model.employeeId = profile.EmployeeID;
                model.EmployeeNo = profile.EmployeeNo;
                model.Name = profile.EmployeeName;
                model.Gender = profile.Gender;
                model.Designation=profile.EmployeeDesignation;
                model.Qualification=profile.EmployeeQualification;
                model.Dateofbirth=profile.EmployeeDOB;
                model.Dateofjoining=profile.EmployeeDOJ;
                model.Address=profile.EmployeeAddress;
                model.MobileNo=profile.EmployeeMobileNo;
                model.SkypeID=profile.EmployeeSkypeID;
                model.EmailID=profile.EmployeeEmailID;
            }
            return model;
        }

        public static Employee Maptoprofile(ProfileModel model)
        {
            Employee profile = new Employee();

            if (profile != null)
            {
                profile.EmployeeID = model.employeeId;
                profile.EmployeeNo = model.EmployeeNo;
                profile.EmployeeName = model.Name;
                profile.Gender = model.Gender;
                profile.EmployeeDesignation = model.Designation;
                profile.EmployeeQualification = model.Qualification;
                profile.EmployeeDOB = model.Dateofbirth;
                profile.EmployeeDOJ = model.Dateofjoining;
                profile.EmployeeAddress = model.Address;
                profile.EmployeeMobileNo = model.MobileNo;
                profile.EmployeeSkypeID = model.SkypeID;
                profile.EmployeeEmailID = model.EmailID;
            }
            return profile;
        }
    }
}