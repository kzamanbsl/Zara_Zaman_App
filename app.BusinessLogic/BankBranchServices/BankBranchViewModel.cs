using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankBranchServices
{
    public  class BankBranchViewModel
    {
        public long Id { get; set; }
        [DisplayName("Branch Name")]
        public string Name { get; set; }
        public long BankId { get; set; }
        public string Address { get; set; }
        public IEnumerable<BankBranchViewModel> BranchList { get; set; }
    }
}
