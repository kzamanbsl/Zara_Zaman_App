using app.EntityModel.DataTableSearchModels;

namespace app.Services.SupplierCategoryServices
{
    public class SupplierCategorySearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
       
    }
}
