using app.EntityModel.AppModels.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels.BankModels
{
    public class BankBranch : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public long BankId { get; set; }
        public Bank Bank { get; set; }
        public Supplier Supplier { get; set; }


    }
}
