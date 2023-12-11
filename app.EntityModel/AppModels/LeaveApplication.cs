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
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string LeaveType { get; set; }
        public int LeaveCategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LeaveDays { get; set; }
        public int LeaveDue { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string AppliedBy { get; set; }
        public DateTime ApplicationDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual LeaveCategory LeaveCategory { get; set; }
       
    }
}
