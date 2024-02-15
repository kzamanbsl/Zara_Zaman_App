using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.AttendanceServices
{
    public class AttendanceSearchDto : BaseDataTableSearch
    {
        [DisplayName("Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [DisplayName("Login Time")]
        public DateTime LoginTime { get; set; }

        [DisplayName("Logout Time")]
        public DateTime? LogoutTime { get; set; }
        public bool IsLogin { get; set; }
        public string Remarks { get; set; }

        public long EmployeeId { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        public long ShiftId { get; set; }
        [DisplayName("Shift Name")]
        public string ShiftName { get; set; }

        public long? ManagerId { get; set; }
        [DisplayName("Manager Name")]
        public string ManagerName { get; set; }

    }
}
