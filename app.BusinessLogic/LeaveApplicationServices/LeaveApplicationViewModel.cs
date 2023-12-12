using app.EntityModel.AppModels;
using app.Services.LeaveCategoryServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.LeaveApplicationServices
{
    public class LeaveApplicationViewModel : BaseViewModel
    {
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string LeaveType { get; set; }
        public int LeaveCategoryId { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public string StayDuringLeave { get; set; }

        public int LeaveDays { get; set; }
        public int LeaveDue { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string AppliedBy { get; set; }
        public DateTime ApplicationDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual LeaveCategory LeaveCategory { get; set; }
        public IEnumerable<LeaveApplicationViewModel> LeaveApplicationList { get; set; }
        public List<LeaveCategory> leaveCategory { get; set; }

    }
}
