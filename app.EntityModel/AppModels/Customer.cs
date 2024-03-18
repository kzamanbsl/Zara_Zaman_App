using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessIdNo { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        //public int? DivisionId { get; set; }
        //public Division Division { get; set; }
        //public int? DistrictId { get; set; }
        //public District District { get; set; }
        //public int? UpazilaId { get; set; }
        //public Upazila Upazila { get; set; }

    }
}
