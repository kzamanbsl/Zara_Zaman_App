namespace app.Services.ProductCategoryServices
{
    public class ProductCategoryViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ProductCategoryViewModel> ProductCategoryList { get; set; }
    }
}
