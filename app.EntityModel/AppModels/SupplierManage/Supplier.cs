using app.EntityModel.AppModels.BankManage;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.EntityModel.AppModels.SupplierManage
{
    public class Supplier : BaseEntity
    {
        public long SupplierCategoryId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Nullable<long> BranchId { get; set; }
        public string BankAccountNo { get; set; }
        public SupplierCategory SupplierCategory { get; set; }

        [ForeignKey(nameof(BranchId))]
        public BankBranch Branch { get; set; }

        //public int? UpazilaId { get; set; }
        //public Upazila Upazila { get; set; }
        //public int? DivisionId { get; set; }
        //public Division Division { get; set; }
        //public int? DistrictId { get; set; }
        //public District District { get; set; } 
        //public int? CountryId { get; set; }
        //public Country Country { get; set; }
    }

}
