using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indpro.Attendance.Entity;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using Indpro.Attendance.Repository;

namespace Indpro.Attendance.Business
{
    public class UserHandler
    {
        public static List<User> GetAllUser()
        {
            return UserRepository.GetAllUser();
        }

        public static User GetEmployee(int UserID)
        {
            return UserRepository.GetEmployee(UserID);
        }

        public static User GetAdmin(string username, string password)
        {
            return UserRepository.GetAdmin(username,password);
        }

        public static void Add(User user)
        {
            UserRepository.Add(user);
        }

        public static void Update(User user)
        {
            UserRepository.Update(user);
        }

        public static void Delete(int id)
        {
            UserRepository.Delete(id);
        }

        public static Dictionary<int, string> GetRoles()
        { 
            return UserRepository.GetRoles();
        }

        public static Dictionary<int, string> GetEmployeeNos()
        { 
            return UserRepository.GetEmployeeNos();
        }

    }
}



