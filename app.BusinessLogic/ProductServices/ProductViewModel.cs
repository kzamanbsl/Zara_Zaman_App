using app.EntityModel.AppModels;
using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.ProductServices
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TP { get; set; }
        public decimal SalePrice { get; set; }
        public Unit Unit { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
        public ProductCategory Category { get; set; }
        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }

    }
}
