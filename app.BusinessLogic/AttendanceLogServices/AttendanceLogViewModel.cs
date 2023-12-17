using app.EntityModel.AppModels;

namespace app.Services.AttendanceLogServices
{
    public class AttendanceLogViewModel:BaseViewModel
    {

        public long AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Remarks { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long ShiftId { get; set; }
        public string ShiftName { get; set; } 
        public long IsSave { get; set; }
        public IEnumerable<AttendanceLogViewModel> AttendanceLogList { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
