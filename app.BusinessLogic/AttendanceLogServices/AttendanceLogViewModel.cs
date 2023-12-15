using System.ComponentModel;
using app.EntityModel.AppModels;

namespace app.Services.AttendanceLogServices
{
    public class AttendanceLogViewModel:BaseViewModel
    {

        public long AttendanceId { get; set; }

        [DisplayName("Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [DisplayName("Login Time")]
        public DateTime LoginTime { get; set; }

        [DisplayName("Logout Time")]
        public DateTime LogoutTime { get; set; }

        public string Remarks { get; set; }
       
        public IEnumerable<AttendanceLogViewModel> AttendanceLogList { get; set; }

    }
}
