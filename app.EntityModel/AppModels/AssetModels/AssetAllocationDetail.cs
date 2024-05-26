using app.EntityModel.AppModels.ProductModels;

namespace app.EntityModel.AppModels.AssetModels
{
    public class AssetAllocationDetail : BaseEntity
    {
        public long AllocationId { get; set; }
        public AssetAllocation Allocation { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public string Tags { get; set; }
        public string Remarks { get; set; }
    }
}
