﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
    }
}
