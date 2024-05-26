using app.EntityModel.AppModels.AssetModels;
using app.EntityModel.AppModels.ProductModels;
using app.Services.AssetAllocationServices;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssetAllocationDetailServices
{
    public class AssetAllocationDetailViewModel : BaseViewModel
    {
        public long AllocationId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public string Tags { get; set; }
        public string[] Tag {get; set;}
        public string Remarks { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetAllocationViewModel AssetAllocationVm { get; set; }
    }
}
