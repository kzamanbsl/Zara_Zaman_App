using app.EntityModel.AppModels;
using app.Services.AssetAllocationDetailServices;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationViewModel : BaseViewModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string OrderNo { get; set; }
        public int AssetAllocationStatusId { get; set; }
        public string AssetAllocationStatusName { get; set; }
        public decimal OverallDiscount { get; set; }
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
