namespace app.EntityModel.AppModels
{
    public class AssetAllocationDetail : BaseEntity
    {
        public long AssetAllocationId { get; set; }
        public AssetAllocation AssetAllocation { get; set; }
        public long? ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }            
        public string Description { get; set; }
    }
}
