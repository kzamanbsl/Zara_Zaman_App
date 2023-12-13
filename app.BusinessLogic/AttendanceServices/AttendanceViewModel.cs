using app.EntityModel.AppModels;
using app.Services.AttendanceLogServices;

namespace app.Services.AttendanceServices
{
    public class AttendanceViewModel:BaseViewModel
    {
        public DateTime AttendanceDate { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Remarks { get; set; }
        //public long AttendanceLogId { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsSave { get; set; } = false;

        public IEnumerable<AttendanceViewModel> AttendanceList { get; set; }
        public List<AttendanceLogViewModel> AttendanceLogList { get; set; }
    }
}
