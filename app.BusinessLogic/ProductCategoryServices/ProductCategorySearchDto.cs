using app.EntityModel.DataTableSearchModels;

namespace app.Services.ProductCategoryServices
{
    public class ProductCategorySearchDto: BaseDataTableSearch
    {
        public int ProductCategoryTypeId { get; set; }
        public string Name { get; set; }
       
    }
}
