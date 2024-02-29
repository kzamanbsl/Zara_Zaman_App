using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.CustomerServices
{
    public class CustomerSearchDto : BaseDataTableSearch
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        [DisplayName("Country Name")]
        public int? CountryId { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        [DisplayName("Division Name")]
        public int? DivisionId { get; set; }

        [DisplayName("Division Name")]
        public string DivisionName { get; set; }

        [DisplayName("District Name")]
        public int? DistrictId { get; set; }

        [DisplayName("District Name")]
        public string DistrictName { get; set; }

        [DisplayName("Upazila Name")]
        public int? UpazilaId { get; set; }

        [DisplayName("Upazila Name")]
        public string UpazilaName { get; set; }
    }
}
