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

        [DisplayName("DivisionName")]
        public int? DivisionId { get; set; }

        [DisplayName("DivisionName")]
        public string DivisionName { get; set; }

        [DisplayName("DistrictName")]
        public int? DistrictId { get; set; }

        [DisplayName("DistrictName")]
        public string DistrictName { get; set; }

        [DisplayName("UpazilaName")]
        public int? UpazilaId { get; set; }

        [DisplayName("UpazilaName")]
        public string UpazilaName { get; set; }
    }
}
