using System.ComponentModel;

namespace app.Services.ProductServices
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public long UnitId { get; set; }

        [DisplayName("Unit")]
        public string UnitName { get; set; }

        public long CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }
        public string HasModelNo { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }

    }
}
