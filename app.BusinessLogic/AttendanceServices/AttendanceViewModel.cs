using System.ComponentModel;

namespace app.Services.AttendanceServices
{
    public class AttendanceViewModel:BaseViewModel
    {
        [DisplayName("Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [DisplayName("Login Time")]
        public DateTime LoginTime { get; set; }

        [DisplayName("Logout Time")]
        public DateTime LogoutTime { get; set; }

        public string Remarks { get; set; }

        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public long? ManagerId { get; set; }
        public string ManagerName { get; set; }

        public IEnumerable<AttendanceViewModel> AttendanceList { get; set; }
    }
}
