using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Utility;
using System.ComponentModel;

namespace app.Services.AssetPurchaseOrderServices
{
    public class AssetPurchaseOrderSearchDto : BaseDataTableSearch
    {
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }

        [DisplayName("PO No")]
        public string OrderNo { get; set; }

        [DisplayName("Status")]
        public int OrderStatusId { get; set; }

        [DisplayName("Status")]
        public string OrderStatusName { get; set; }
        public decimal OverallDiscount { get; set; }
        public double TotalAmount { get; set; }
        public int PurchaseTypeId { get; set; }
        public bool IsOpening { get; set; } = false;

        [DisplayName("Supplier")]
        public long? SupplierId { get; set; }

        [DisplayName("Supplier")]
        public Supplier Supplier { get; set; }

        [DisplayName("Supplier")]
        public string SupplierName { get; set; }

        [DisplayName("Storehouse")]
        public long? StorehouseId { get; set; }

        [DisplayName("Storehouse")]
        public BusinessCenter Storehouse { get; set; }

        [DisplayName("Storehouse")]
        public string StoreName { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetPurchaseOrderDetailViewModel AssetPurchaseOrderDetailVM { get; set; } 
       
    }
}
