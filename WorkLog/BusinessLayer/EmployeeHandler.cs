using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indpro.Attendance.Entity;
using System.Data.SqlClient;
using Indpro.Attendance.Repository;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace Indpro.Attendance.Business
{
    public class EmployeeHandler
    {
        public static List<Employee> GetAllEmployee()
        {
            return EmployeeRepository.GetAllEmployee();
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
                 VALUES({0},'{1}',{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", employee.EmployeeNo,
                            employee.EmployeeName, (int)employee.Gender, employee.EmployeeDesignation, employee.EmployeeQualification,
                               employee.EmployeeDOB, employee.EmployeeDOJ, employee.EmployeeImage, employee.EmployeeAddress,
                                    employee.EmployeeMobileNo, employee.EmployeeSkypeID, employee.EmployeeEmailID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }


        public static void Update(Employee employee)
        {
            var sql = string.Format(@"UPDATE IP_Employee SET EmployeeNO='{0}', EmployeeName='{1}', Gender={2}, EmployeeDesignation='{3}',
                                      EmployeeQualification='{4}', EmployeeDOB='{5}', EmployeeDOJ='{6}', EmployeeImage='{7}',EmployeeAddress='{8}',
                                      EmployeeMobileNo='{9}', EmployeeSkypeID='{10}', EmployeeEmailID='{11}'                   
                                      WHERE EmployeeID={12}", employee.EmployeeNo, employee.EmployeeName, (int)employee.Gender,
                                       employee.EmployeeDesignation, employee.EmployeeQualification, employee.EmployeeDOB, employee.EmployeeDOJ,
                                       employee.EmployeeImage, employee.EmployeeAddress, employee.EmployeeMobileNo, employee.EmployeeSkypeID,
                                       employee.EmployeeEmailID, employee.EmployeeID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);

        }


        public static void Delete(int id)
        {
            var sql = string.Format(@"DELETE FROM IP_Employee where EmployeeID={0}", id);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

    }
}