using System.ComponentModel;

namespace app.Services.SupplierServices
{
    public class SupplierViewModel:BaseViewModel
    {
        public long SupplierCategoryId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        public string Description { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAccountNo { get; set; }
        public long BankId { get; set; }
        public long BankBranchId { get; set; }


        //public int? CountryId { get; set; }
        //[DisplayName("Country Name")]
        //public string CountryName { get; set; }
        //public int? DivisionId { get; set; }
        //[DisplayName("Division Name")]
        //public string DivisionName { get; set; }
        //public int? DistrictId { get; set; }
        //[DisplayName("District Name")]
        //public string DistrictName { get; set; }
        //public int? UpazilaId { get; set; }
        //[DisplayName("Upazila Name")]
        //public string UpazilaName { get; set; }

        public IEnumerable<SupplierViewModel> SupplierList { get; set; }
    }
}
