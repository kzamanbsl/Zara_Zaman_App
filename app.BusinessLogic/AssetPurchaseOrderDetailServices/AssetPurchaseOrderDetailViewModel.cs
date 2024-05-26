using app.EntityModel.AppModels.ProductModels;
using app.EntityModel.AppModels.PurchaseModels;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssetPurchaseOrderDetailServices
{
    public class AssetPurchaseOrderDetailViewModel : BaseViewModel
    {
        public long PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [Required(ErrorMessage = "Select Product")]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public string UnitName { get; set; }
        public double Consumption { get; set; }
        public double PurchaseQty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetPurchaseOrderViewModel AssetPurchaseOrderVM { get; set; }
    }
}
