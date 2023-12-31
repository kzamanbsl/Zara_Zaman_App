using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using app.Utility;
using app.Services.LeaveBalanceServices;

namespace app.Services.LeaveApplicationServices
{
    public class LeaveApplicationViewModel : BaseViewModel
    {
        public long EmployeeId { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        public long? ManagerId { get; set; }
        [DisplayName("Manager Name")]
        public string ManagerName { get; set; }
      
        public long LeaveCategoryId { get; set; }
        [DisplayName("Leave Category Name")]
        public string LeaveCategoryName { get; set; }

        [Required]
        [DisplayName("Start Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        [DisplayName("Leave Days")]
        public int LeaveDays { get; set; }

        [DisplayName("Stay During Leave")]
        public string StayDuringLeave { get; set; }

        public string Reason { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Application Date")]
        public DateTime ApplicationDate { get; set; }= DateTime.Now;

        public int StatusId { get; set; }
        [DisplayName("Status")]
        public string StatusName => GlobalVariable.GetEnumDescription((LeaveApplicationStatusEnum)StatusId);

        public IEnumerable<LeaveBalanceCountViewModel> LeaveBalanceCountList { get; set; }

        public IEnumerable<LeaveApplicationViewModel> LeaveApplicationList { get; set; }


    }
}
