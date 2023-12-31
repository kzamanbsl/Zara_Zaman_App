﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public long? UpazilaId { get; set; }
        public Upazila Upazila { get; set; }
        public long? DivisionId { get; set; }
        public Division Division { get; set; }
        public long? DistrictId { get; set; }
        public District District { get; set; } 
        public long? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
