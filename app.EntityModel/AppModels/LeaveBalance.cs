using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class LeaveBalance : BaseEntity
    {
        public int LeaveQty { get; set; }  
        public string Description { get; set; }
        public long LeaveCategoryId { get; set; }
        public LeaveCategory LeaveCategory { get; set; }

    }
}
