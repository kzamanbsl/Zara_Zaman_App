using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.SupplierServices
{
    public class SupplierSearchDto: BaseDataTableSearch
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAccountNo { get; set; }

        //[DisplayName("Country Name")]
        //public int? CountryId { get; set; }

        //[DisplayName("Country Name")]
        //public string CountryName { get; set; }

        //[DisplayName("Division Name")]
        //public int? DivisionId { get; set; }

        //[DisplayName("Division Name")]
        //public string DivisionName { get; set; }

        //[DisplayName("District Name")]
        //public int? DistrictId { get; set; }

        //[DisplayName("District Name")]
        //public string DistrictName { get; set; }

        //[DisplayName("Upazila Name")]
        //public int? UpazilaId { get; set; }

        //[DisplayName("Upazila Name")]
        //public string UpazilaName { get; set; }

    }
}
