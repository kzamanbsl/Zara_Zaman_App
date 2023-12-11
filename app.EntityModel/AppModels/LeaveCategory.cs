using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class LeaveCategory : BaseEntity
    {
        public string Name { get; set; }
        //public List<LeaveBalance> Balances { get; set; }
        public List<LeaveBalance> LeaveBalances { get; set; }

    }
}
