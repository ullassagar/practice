using System;
using System.Collections.Generic;
using System.Data;
using Indpro.Attendance.Entity;
using Microsoft.ApplicationBlocks.Data;

namespace Indpro.Attendance.Repository
{
    public class EmployeeRepository
    {
        public static List<Employee> GetAllEmployee()
        {
            var employeeList = new List<Employee>();

            var sql = @"SELECT EmployeeID, EmployeeNO, EmployeeName, Gender, EmployeeDesignation, EmployeeQualification, EmployeeDOB, EmployeeDOJ,
                        EmployeeImage, EmployeeAddress, EmployeeMobileNo, EmployeeSkypeID, EmployeeEmailID 
                        FROM IP_Employee";

            using (var reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
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
                                      FROM IP_Employee
                                      Where EmployeeId={0}", employeeId);

            using (var reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
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
            var sql = string.Format(@"INSERT INTO IP_Employee(EmployeeName, Gender, EmployeeDesignation, EmployeeQualification,
                                    EmployeeDOB, EmployeeDOJ, EmployeeImage, EmployeeAddress, EmployeeMobileNo, EmployeeSkypeID, EmployeeEmailID)
                                    VALUES('{0}', {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'); SELECT @@IDENTITY;",
                employee.EmployeeName, (int)employee.Gender, employee.EmployeeDesignation, employee.EmployeeQualification,
                employee.EmployeeDOB, employee.EmployeeDOJ, employee.EmployeeImage, employee.EmployeeAddress,
                employee.EmployeeMobileNo, employee.EmployeeSkypeID, employee.EmployeeEmailID);

            employee.EmployeeID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql));

            employee.EmployeeNo = employee.EmployeeDOJ.ToString("yyMMdd") + string.Format("{0:D4}", employee.EmployeeID);

            sql = string.Format(@"UPDATE IP_Employee SET EmployeeNo='{0}'                   
                                WHERE EmployeeID={1}", employee.EmployeeNo, employee.EmployeeID);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Update(Employee employee)
        {
            var sql = string.Format(@"UPDATE IP_Employee SET EmployeeName='{0}', Gender={1}, EmployeeDesignation='{2}',
                                      EmployeeQualification='{3}', EmployeeDOB='{4}', EmployeeDOJ='{5}', EmployeeImage='{6}',EmployeeAddress='{7}',
                                      EmployeeMobileNo='{8}', EmployeeSkypeID='{9}', EmployeeEmailID='{10}'                   
                                      WHERE EmployeeID={11}", employee.EmployeeName, (int)employee.Gender,
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