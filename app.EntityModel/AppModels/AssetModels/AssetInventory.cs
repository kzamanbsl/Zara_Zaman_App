using app.EntityModel.AppModels.ProductModels;

namespace app.EntityModel.AppModels.AssetModels
{
    public class AssetInventory : BaseEntity
    {
        public DateTime StockDate { get; set; }
        public int StoreTypeId { get; set; } //Purchase Or Manufacture Enum Value
        public long StoreFromId { get; set; } //Purchase Or Manufacture
        public long StorehouseId { get; set; }
        public BusinessCenter Storehouse { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public double Consumption { get; set; }
        public decimal CostPrice { get; set; }
        public string Remarks { get; set; }
    }
}
