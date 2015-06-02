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
            return EmployeeRepository.GetEmployee(employeeId);
        }
        
        public static void Add(Employee employee)
        {
            EmployeeRepository.Add(employee);
        }

        public static void Update(Employee employee)
        {
           EmployeeRepository.Update(employee);

        }
        
        public static void Delete(int id)
        {
            EmployeeRepository.Delete(id);
        }

    }
}