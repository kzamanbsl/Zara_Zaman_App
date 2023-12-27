using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TP { get; set; }
        public decimal SalePrice { get; set; }
        public Unit Unit { get; set; }
        public long UnitId { get; set; }
        public ProductCategory Category { get; set; }
        public long CategoryId { get; set; }

    }
}
