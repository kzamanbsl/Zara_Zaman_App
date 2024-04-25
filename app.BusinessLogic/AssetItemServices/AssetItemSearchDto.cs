using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.AssetItemServices
{
    public class AssetItemSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }

        [DisplayName("Unit ")]
        public long UnitId { get; set; }

        [DisplayName("Unit ")]
        public string UnitName { get; set; }

        [DisplayName("Category ")]
        public long CategoryId { get; set; }

        [DisplayName("Category ")]
        public string CategoryName { get; set; }
    }
}
