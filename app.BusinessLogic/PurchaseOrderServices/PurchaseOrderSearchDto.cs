using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using System.ComponentModel;

namespace app.Services.PurchaseOrderServices
{
    public class PurchaseOrderSearchDto : BaseDataTableSearch
    {
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }

        [DisplayName("Order No")]
        public string OrderNo { get; set; }

        [DisplayName("OrderStatus Name")]
        public int OrderStatusId { get; set; }

        [DisplayName("OrderStatus Name")]
        public string OrderStatusName { get; set; }

        [DisplayName("Overall Discount")]
        public decimal OverallDiscount { get; set; }

        [DisplayName("Total Amount")]
        public double TotalAmount { get; set; }

        [DisplayName("PurchaseType Name")]
        public int PurchaseTypeId { get; set; }
        public bool IsOpening { get; set; } = false;


        [DisplayName("Supplier Name")]
        public long? SupplierId { get; set; }


        [DisplayName("Supplier Name")]
        public Supplier Supplier { get; set; }


        [DisplayName("OrderStatus Name")]
        public string SupplierName { get; set; }


        [DisplayName("Storehouse Name")]
        public long? StorehouseId { get; set; }

        [DisplayName("Storehouse Name")]
        public BusinessCenter Storehouse { get; set; }

        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public PurchaseOrderDetailViewModel PurchaseOrderDetailVM { get; set; } 
        //public IEnumerable<PurchaseOrderViewModel> PurchaseOrderList { get; set; }
        //public IEnumerable<PurchaseOrderDetailViewModel> PurchaseOrderDetailsList { get; set; }
    }
}
