using app.EntityModel.DataTableSearchModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankBranchServices
{
    public  class BankBranchSearchDto : BaseDataTableSearch
    {
        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
        public string Address { get; set; }
        
    }
}
