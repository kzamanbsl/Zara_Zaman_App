using app.EntityModel.AppModels;
using app.Services.PurchaseOrderDetailServices;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.PurchaseOrderServices
{
    public class PurchaseOrderViewModel : BaseViewModel
    {
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public string OrderNo { get; set; }
        public string OrderStatusId { get; set; }
        public decimal OverallDiscount { get; set; }
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long? StorehouseId { get; set; }
        public Storehouse Storehouse { get; set; }
        public PurchaseOrderDetailViewModel PurchaseOrderDetailVM { get; set; } 
        public IEnumerable<PurchaseOrderViewModel> PurchaseOrderList { get; set; }
    }
}
