using app.EntityModel.DataTableSearchModels;

namespace app.Services.AssetCategoryServices
{
    public class AssetCategorySearchDto: BaseDataTableSearch
    {
        public int AssetCategoryTypeId { get; set; }
        public string Name { get; set; }
    }
}
