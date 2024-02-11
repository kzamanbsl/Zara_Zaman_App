using app.EntityModel.AppModels;

namespace app.Services.ProductServices
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TradePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ProductTypeId { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
         public long CategoryId { get; set; }
        public string CategoryName { get; set; }
     
        public IEnumerable<ProductViewModel> ProductList { get; set; }

    }
}
