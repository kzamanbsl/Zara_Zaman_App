using app.EntityModel.AppModels;

namespace app.Services.AttendanceServices
{
    public class AttendanceViewModel:BaseViewModel
    {
        public DateTime AttendanceDate { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Remarks { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public IEnumerable<AttendanceViewModel> AttendanceList { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Shift> Shifts { get; set; }

    }
}
