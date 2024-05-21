using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels.BankManage
{
    public  class BankBranch:BaseEntity
    {

        public string Name { get; set; } 
        public string Address { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }

    }
}
