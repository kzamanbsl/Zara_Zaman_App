﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
