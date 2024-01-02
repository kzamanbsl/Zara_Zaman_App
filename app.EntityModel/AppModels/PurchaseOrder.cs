using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class PurchaseOrder : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string PurchaseOrderStatus { get; set; }
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
