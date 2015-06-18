using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indpro.Attendance.WebApp;
using Indpro.Attendance.Entity;
using System.ComponentModel.DataAnnotations;
using Indpro.Attendance.Business;

namespace Indpro.Attendance.WebApp.Models
{

    public class ProfileLogModel : MasterModel
    {
        [DataType(DataType.DateTime)]
        public DateTime LogDate { get; set; }

        [Required(ErrorMessage = "Select LogType")]
        public LogType LogType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LogListDate { get; set; }

        public List<ProfileLogDetail> LogList { get; set; }

        public string Error { get; set; }

        public ProfileLogModel()
        {
            Title = "Employee:Log ";
            ActiveModel = "Log";
        }
    }

    public class ProfileLogDetail
    {
        public LogType LogType { get; set; }

        public DateTime LoggedTime { get; set; }

        public bool IsInTime { get; set; }

        public string Error { get; set; }
    }

    public class ProfileLogMapper
    {
        public static List<ProfileLogDetail> MapToProfileLogDetailList(List<LogTime> LogList)
        {
            List<ProfileLogDetail> List = new List<ProfileLogDetail>();

            foreach (LogTime log in LogList)
            {
                ProfileLogDetail p = new ProfileLogDetail();
                p.LogType = log.LogType;
                p.LoggedTime = log.LoggedTime;
                p.IsInTime = log.IsInTime;
                List.Add(p);
            }
            return List;
        }
    }

}