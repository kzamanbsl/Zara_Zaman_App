using System.ComponentModel;
using app.Services.AttendanceLogServices;

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
        public string EmployeeCode { get; set; }
        public bool IsSave { get; set; } = false;

        public IEnumerable<AttendanceViewModel> AttendanceList { get; set; }
        public List<AttendanceLogViewModel> AttendanceLogList { get; set; }
    }
}
