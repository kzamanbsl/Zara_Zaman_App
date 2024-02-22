using app.EntityModel.DataTableSearchModels;
using app.Services.ProductCategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetCategoryServices
{
    public class AssetCategorySearchDto: BaseDataTableSearch
    {
        public int AssetCategoryTypeId { get; set; }
        public string Name { get; set; }
    }
}
