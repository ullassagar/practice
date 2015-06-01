using Indpro.Attendance.Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indpro.Attendance.Repository
{
   public class EmployeeRepository
    {
        public static List<Employee> GetAllEmployee()
        {
            List<Employee> employeeList = new List<Employee>();

            var sql = @"SELECT EmployeeID, EmployeeNO, EmployeeName, Gender, EmployeeDesignation, EmployeeQualification, EmployeeDOB, EmployeeDOJ,
                        EmployeeImage, EmployeeAddress, EmployeeMobileNo, EmployeeSkypeID, EmployeeEmailID 
                        FROM IndproAttendance.dbo.IP_Employee";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    employeeList.Add(Employee.Load(reader));
                }
            }

            return employeeList;

        }
    }
}
