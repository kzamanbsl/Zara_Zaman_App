using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class AttendanceLog : BaseEntity
    {
        public long AttendanceId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Remarks { get; set; }

    }
}
