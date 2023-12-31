using app.EntityModel.AppModels;
using System.ComponentModel;

namespace app.Services.SupplierServices
{
    public class SupplierViewModel:BaseViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public string Description { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public long? UpazilaId { get; set; }
        [DisplayName("Upazila Name")]
        public string UpazilaName { get; set; }
        public long? DivisionId { get; set; }
        [DisplayName("Division Name")]
        public string DivisionName { get; set; }
        public long? DistrictId { get; set; }
        [DisplayName("District Name")]
        public string DistrictName { get; set; }
        public long? CountryId { get; set; }
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        public IEnumerable<SupplierViewModel> SupplierList { get; set; }
    }
}
