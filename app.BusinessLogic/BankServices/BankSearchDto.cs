using app.EntityModel.DataTableSearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.BankServices
{
    public  class BankSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }

    }
}
