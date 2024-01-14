namespace app.Services.ProductCategoryServices
{
    public class ProductCategoryViewModel:BaseViewModel
    {
        public int ProductCategoryTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductCategoryViewModel> ProductCategoryList { get; set; }
    }
}
