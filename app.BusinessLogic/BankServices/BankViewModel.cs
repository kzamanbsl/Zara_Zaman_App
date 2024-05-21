using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankServices
{
    public  class BankViewModel
    {
        public long Id { get; set; }
        [DisplayName("Bank Name")]
        public string  Name { get; set; }
        public List<BankViewModel> BankList { get; set; }
    }
}
