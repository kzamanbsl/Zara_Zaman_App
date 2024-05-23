using app.EntityModel.AppModels.BankManage;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.EntityModel.AppModels.SupplierManage
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public long SupplierCategoryId { get; set; }
        public long? BranchId { get; set; }
        public string BankAccountNo { get; set; }

        public SupplierCategory SupplierCategory { get; set; }
        public BankBranch Branch { get; set; }

        
    }

}
