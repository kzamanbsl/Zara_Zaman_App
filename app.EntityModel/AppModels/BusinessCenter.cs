﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class BusinessCenter : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
       
    }
}
