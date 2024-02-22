using app.EntityModel.DataTableSearchModels;

namespace app.Services.LeaveCategoryServices
{
    public class LeaveCategorySearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
    }
}
