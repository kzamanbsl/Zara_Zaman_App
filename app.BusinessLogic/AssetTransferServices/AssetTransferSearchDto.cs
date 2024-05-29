using app.EntityModel.DataTableSearchModels;
using app.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetTransferServices
{
    public  class AssetTransferSearchDto:BaseDataTableSearch
    {
        [DisplayName("Transfer No")]
        public string TransferNo { get; set; }

        [DisplayName("Transfer Date")]
        public DateTime Date { get; set; }

        [DisplayName("From Store")]
        public long FromStoreId { get; set; }

        [DisplayName("From Store")]
        public string FromStoreName { get; set; }

        [DisplayName("To Store")]
        public long ToStoreId { get; set; }

        [DisplayName("To Store")]
        public string ToStoreName { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [DisplayName("Status")]
        public string StatusName => GlobalVariable.GetEnumDescription((AssetTransferStatusEnum)StatusId);

        public string Description { get; set; }
    }
}
