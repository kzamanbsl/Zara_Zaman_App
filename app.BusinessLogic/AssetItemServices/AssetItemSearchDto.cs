﻿using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetItemServices
{
    public class AssetItemSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TP { get; set; }
        public decimal SalePrice { get; set; }
        public int ProductTypeId { get; set; }
        public Unit Unit { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public ProductCategory Category { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}