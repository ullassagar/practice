using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class Employee
    {
        public int EmployeeID { get; set; }

          [StringLength(60, MinimumLength = 3)]
           [Required(ErrorMessage = "EmployeeNo  Required")]
        public int EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmployeeQualification { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public DateTime EmployeeDOJ { get; set; }
        public string EmployeeImage { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeMobileNo { get; set; }
        public string EmployeeSkypeID { get; set; }
        public string EmployeeEmailID { get; set; }

        public static Employee Load(IDataReader reader)
        {
            Employee employee = new Employee();
            employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            employee.EmployeeNo = Convert.ToInt32(reader["EmployeeNo"]);
            employee.EmployeeName = Convert.ToString(reader["EmployeeName"]);
            employee.Gender = (Gender)Convert.ToInt32(reader["Gender"]);
            employee.EmployeeDesignation = Convert.ToString(reader["EmployeeDesignation"]);
            employee.EmployeeQualification = Convert.ToString(reader["EmployeeQualification"]);
            employee.EmployeeDOB = Convert.ToDateTime(reader["EmployeeDOB"]);
            employee.EmployeeDOJ = Convert.ToDateTime(reader["EmployeeDOJ"]);
            employee.EmployeeImage = Convert.ToString(reader["EmployeeImage"]);
            employee.EmployeeAddress = Convert.ToString(reader["EmployeeAddress"]);
            employee.EmployeeMobileNo = Convert.ToString(reader["EmployeeMobileNo"]);
            employee.EmployeeSkypeID = Convert.ToString(reader["EmployeeSkypeID"]);
            employee.EmployeeEmailID = Convert.ToString(reader["EmployeeEmailID"]);
            return employee;
        }
    }
}
