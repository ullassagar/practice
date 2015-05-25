using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace BusinessLayer
{
    public class EmployeeHandler
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

        public static Employee GetEmployee(int employeeId)
        {
            Employee employee = null;

            var sql = string.Format(@"SELECT EmployeeID, EmployeeNO, EmployeeName, Gender, EmployeeDesignation, EmployeeQualification,
                                      EmployeeDOB, EmployeeDOJ, EmployeeImage, EmployeeAddress, EmployeeMobileNo, EmployeeSkypeID, EmployeeEmailID
                                      FROM IndproAttendance.dbo.IP_Employee
                                      Where EmployeeId={0}", employeeId);

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    employee = Employee.Load(reader);
                }
            }

            return employee;
        }

        public static void Add(Employee employee)
        {
            var sql = string.Format(@"INSERT INTO IndproAttendance.dbo.IP_Employee(EmployeeNO,EmployeeName,Gender,EmployeeDesignation
                ,EmployeeQualification,EmployeeDOB,EmployeeDOJ,EmployeeImage,EmployeeAddress,EmployeeMobileNo,EmployeeSkypeID,EmployeeEmailID)
                 VALUES('{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",employee.EmployeeNo,
                            employee.EmployeeName,(int)employee.Gender,employee.EmployeeDesignation,employee.EmployeeQualification,
                               employee.EmployeeDOB,employee.EmployeeDOJ,employee.EmployeeImage,employee.EmployeeAddress,
                                    employee.EmployeeMobileNo,employee.EmployeeSkypeID,employee.EmployeeEmailID);

             

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

    }
}