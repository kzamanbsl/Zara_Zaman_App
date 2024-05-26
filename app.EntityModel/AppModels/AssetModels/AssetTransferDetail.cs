using app.EntityModel.AppModels.ProductModels;

namespace app.EntityModel.AppModels.AssetModels
{
    public class AssetTransferDetail : BaseEntity
    {
        public long TransferId { get; set; }
        public AssetTransfer Transfer { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
    }
}
