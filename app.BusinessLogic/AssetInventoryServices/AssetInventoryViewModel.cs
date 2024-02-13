using app.EntityModel.AppModels;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Services.AssetPurchaseOrderServices;

namespace app.Services.InventoryServices
{
    public class AssetInventoryViewModel : BaseViewModel
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
        public AssetPurchaseOrderDetailViewModel AssetPurchaseOrderDetailVM { get; set; }
        public AssetPurchaseOrderViewModel AssetPurchaseOrderVM { get; set; }
        public AssetInventoryViewModel AssetInventoryVM{ get; set; }
        public IEnumerable<AssetInventoryViewModel> AssetInventoryList { get; set; }
        public IEnumerable<AssetPurchaseOrderViewModel> AssetPurchaseOrderList { get; set; }
        public IEnumerable<AssetPurchaseOrderDetailViewModel> AssetPurchaseOrderDetailsList { get; set; }

    }
}
