using app.EntityModel.AppModels;
using app.Services.AssetTransferDetailServices;
using app.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTransferServices
{
    public  class AssetTransferViewModel : BaseViewModel
    {
        public string TransferNo { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public long FromStoreId { get; set; }
        public string FromStoreName{ get; set; }
        public long ToStoreId { get; set; }
        public string ToStoreName { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName => GlobalVariable.GetEnumDescription((AssetTransferStatusEnum)StatusId);
       public AssetTransferDetailViewModel Detail { get; set; }
       public List<AssetTransferDetailViewModel> DetailList { get; set; }
    }
}
