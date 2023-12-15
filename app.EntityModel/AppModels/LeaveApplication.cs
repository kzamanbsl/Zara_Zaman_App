using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class LeaveApplication : BaseEntity
    {

        public DateTime ApplicationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveDays { get; set; }
        public string Reason { get; set; }
        public string StayDuringLeave { get; set; }
        public string Remarks { get; set; }
        public int StatusId { get; set; }
        public long LeaveCategoryId { get; set; }
        public virtual LeaveCategory LeaveCategory { get; set; }
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

    }
}
