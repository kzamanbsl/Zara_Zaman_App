namespace app.EntityModel.AppModels
{
    public class AssetAllocation : BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string OrderNo { get; set; }
        public int AssetAllocationStatusId { get; set; }
        public int Quantity { get;set; }
        public string Tags { get; set; }
        public string Remarks { get; set; }
       
    }
}

