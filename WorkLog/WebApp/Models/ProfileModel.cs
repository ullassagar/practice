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

         public ProfileModel()
        {
            Title = "Employee:Profile ";
            ActiveModel = "Profile";
        }
    }
}