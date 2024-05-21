using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.AppModels.Office;
using app.EntityModel.AppModels.EmployeeManage;

namespace app.EntityModel.AppModels.Attendance;

public class Attendance : BaseEntity
{
    public DateTime AttendanceDate { get; set; }
    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }
    public string Remarks { get; set; }
    public long EmployeeId { get; set; }
    public Employee Employee { get; set; }
    //public long AttendanceLogId { get; set; }
    //public AttendanceLog AttendanceLog { get; set; }
    public long ShiftId { get; set; }
    public Shift Shift { get; set; }

}
