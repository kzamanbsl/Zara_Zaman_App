using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Attendance : BaseEntity
    {        
        public DateTime AttendanceDate { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }        
        public string Remarks { get; set; }
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        //public long AttendanceLogId { get; set; }
        //public AttendanceLog AttendanceLog { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
    }
}
