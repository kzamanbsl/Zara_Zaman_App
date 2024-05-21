namespace app.EntityModel.AppModels.SupplierManage;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string BankName { get; set; }
    public string BranchName { get; set; }
    public string BankAccountNo { get; set; }
    public long SupplierCategoryId { get; set; }
    public SupplierCategory SupplierCategory { get; set; }

    //public int? UpazilaId { get; set; }
    //public Upazila Upazila { get; set; }
    //public int? DivisionId { get; set; }
    //public Division Division { get; set; }
    //public int? DistrictId { get; set; }
    //public District District { get; set; } 
    //public int? CountryId { get; set; }
    //public Country Country { get; set; }
}
