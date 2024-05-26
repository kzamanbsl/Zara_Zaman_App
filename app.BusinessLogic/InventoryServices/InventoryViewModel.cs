using app.EntityModel.AppModels.ProductModels;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;

namespace app.Services.InventoryServices
{
    public class InventoryViewModel : BaseViewModel
    {
        public DateTime StockDate { get; set; }
        public int StoreTypeId { get; set; } //Purchase Or Manufecture Enum Value
        public long StoreFromId { get; set; } //Purchase Or Manufecture
        public long StorehouseId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public double Consumption { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Remarks { get; set; }
        public PurchaseOrderDetailViewModel PurchaseOrderDetailVM { get; set; }
        public PurchaseOrderViewModel PurchaseOrderVM { get; set; }
        public InventoryViewModel InventoryVM{ get; set; }
        public IEnumerable<InventoryViewModel> InventoryList { get; set; }
        public IEnumerable<PurchaseOrderViewModel> PurchaseOrderList { get; set; }
        public IEnumerable<PurchaseOrderDetailViewModel> PurchaseOrderDetailsList { get; set; }

    }
}
