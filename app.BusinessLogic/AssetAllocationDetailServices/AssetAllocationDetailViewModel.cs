using app.EntityModel.AppModels;
using app.EntityModel.AppModels.AssetManage;
using app.Services.AssetAllocationServices;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssetAllocationDetailServices
{
    public class AssetAllocationDetailViewModel : BaseViewModel
    {
        public long AssetAllocationId { get; set; }
        public AssetAllocation AssetAllocation { get; set; }
        public string AssetAllocationName { get; set; }
        public long? ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }
        public string[] Tag {get; set;}
        public string Description { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetAllocationViewModel AssetAllocationVM { get; set; }
    }
}
