using app.EntityModel.AppModels;
using app.Services.AssetAllocationDetailServices;
using app.Utility;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Select Product")]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }
        public string Remarks { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetAllocationDetailViewModel AssetAllocationDetailVM { get; set; } 
        public IEnumerable<AssetAllocationViewModel> AssetAllocationList { get; set; }
        public IEnumerable<AssetAllocationDetailViewModel> AssetAllocationDetailsList { get; set; }
    }
}
