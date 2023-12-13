using app.EntityModel.AppModels;
using app.Services.LeaveCategoryServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Utility;

namespace app.Services.LeaveApplicationServices
{
    public class LeaveApplicationViewModel : BaseViewModel
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long ManagerId { get; set; }
        public string ManagerName { get; set; }
      
        public long LeaveCategoryId { get; set; }
        public string LeaveCategoryName { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public int LeaveDays { get; set; }
        public string StayDuringLeave { get; set; }

        public string Reason { get; set; }
        public string Remarks { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get { return GlobalVariable.GetEnumDescription((LeaveApplicationStatusEnum)StatusId); } }

        public IEnumerable<LeaveApplicationViewModel> LeaveApplicationList { get; set; }


    }
}
