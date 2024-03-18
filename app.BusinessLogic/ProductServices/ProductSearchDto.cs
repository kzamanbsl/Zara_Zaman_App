﻿using System.ComponentModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.ProductServices
{
    public class ProductSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [DisplayName("Model No")]
        public string HasModelNo { get; set; }
        public int ProductTypeId { get; set; }

        [DisplayName("Unit Name")]
        public long UnitId { get; set; }

        [DisplayName("Unit Name")]
        public string UnitName { get; set; }

        [DisplayName("Category Name")]
        public long CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
