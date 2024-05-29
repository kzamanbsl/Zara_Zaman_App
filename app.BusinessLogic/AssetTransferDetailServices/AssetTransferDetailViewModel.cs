using app.EntityModel.AppModels.AssetModels;
using app.EntityModel.AppModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTransferDetailServices
{
    public  class AssetTransferDetailViewModel:BaseViewModel
    {
        public long TransferId { get; set; }
        public long ProductId { get; set; }
        public string ProductName{ get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
    }
}
