using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class PurchaseOrderList : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public string OrderNo { get; set; }
        public int OrderStatusId { get; set; }
        public  decimal OverallDiscount { get; set; }
        public int PurchaseTypeId { get;set; }
        public bool IsOpening { get; set; } = false;
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long? StorehouseId { get; set;}
        public BusinessCenter Storehouse { get; set; }

    }
}
