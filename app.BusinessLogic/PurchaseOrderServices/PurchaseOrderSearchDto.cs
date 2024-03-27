using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using System.ComponentModel;

namespace app.Services.PurchaseOrderServices
{
    public class PurchaseOrderSearchDto : BaseDataTableSearch
    {

        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }

        [DisplayName("PO No")]
        public string OrderNo { get; set; }

        [DisplayName("Status")]
        public int OrderStatusId { get; set; }

        [DisplayName("Status")]
        public string OrderStatusName { get; set; }

        [DisplayName("Total Amount")]
        public double TotalAmount { get; set; }

        [DisplayName("Purchase Type")]
        public int PurchaseTypeId { get; set; }
        public bool IsOpening { get; set; } = false;


        [DisplayName("Supplier")]
        public long? SupplierId { get; set; }


        [DisplayName("Supplier")]
        public Supplier Supplier { get; set; }


        [DisplayName("Supplier")]
        public string SupplierName { get; set; }


        [DisplayName("Warehouse")]
        public long? StorehouseId { get; set; }

        [DisplayName("Warehouse")]
        public BusinessCenter Storehouse { get; set; }

        [DisplayName("Warehouse")]
        public string StoreName { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public PurchaseOrderDetailViewModel PurchaseOrderDetailVM { get; set; }
    }
}
