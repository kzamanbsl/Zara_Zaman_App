using app.EntityModel.AppModels;

namespace app.Services.AssetItemServices
{
    public class AssetItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HasModelNo { get; set; }
        public int ProductTypeId { get; set; }
        public Unit Unit { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public ProductCategory Category { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<AssetItemViewModel> AssetItemList { get; set; }
    }
}
