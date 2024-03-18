using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetItemServices
{
    public class AssetItemSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        [DisplayName("Unit Name")]
        public Unit Unit { get; set; }
        [DisplayName("Unit Name")]
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        [DisplayName("Category Name")]
        public ProductCategory Category { get; set; }
        [DisplayName("Category Name")]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
