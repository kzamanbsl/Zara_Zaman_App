using app.EntityModel.AppModels;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.CustomerServices
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? UpazilaId { get; set; }
        public string UpazilaName { get; set; }
        public IEnumerable<CustomerViewModel> CustomerList { get; set; }
    }
}
