using app.EntityModel.AppModels;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
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
        public PurchaseOrderStatusEnum OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public decimal OverallDiscount { get; set; }
        public double TotalAmount { get; set; }
        public int PurchaseTypeId { get; set; }
        public bool IsOpening { get; set; } = false;
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string SupplierName { get; set; } 
        public long? StorehouseId { get; set; }
        public BusinessCenter Storehouse { get; set; }
        public string StoreName { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public PurchaseOrderDetailViewModel PurchaseOrderDetailVM { get; set; } 
        public IEnumerable<PurchaseOrderViewModel> PurchaseOrderList { get; set; }
        public IEnumerable<PurchaseOrderDetailViewModel> PurchaseOrderDetailsList { get; set; }
    }
}
