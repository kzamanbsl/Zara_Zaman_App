using app.Services.ProductCategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetCategoryServices
{
    public class AssetCategoryViewModel: BaseViewModel
    {
        public int AssetCategoryTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<AssetCategoryViewModel> AssetCategoryList { get; set; }
    }
}
