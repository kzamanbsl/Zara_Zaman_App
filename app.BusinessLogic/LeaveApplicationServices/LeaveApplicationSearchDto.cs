using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using app.Utility;
using app.Services.LeaveBalanceServices;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.LeaveApplicationServices
{
    public class LeaveApplicationSearchDto : BaseDataTableSearch
    {
        [DisplayName("Employee Name")]
        public long EmployeeId { get; set; }
        
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Manager Name")]
        public long? ManagerId { get; set; }

        [DisplayName("Manager Name")]
        public string ManagerName { get; set; }

        [DisplayName("Leave Category Name")]
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

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [DisplayName("Status")]
        public string StatusName => GlobalVariable.GetEnumDescription((LeaveApplicationStatusEnum)StatusId);

    }
}
