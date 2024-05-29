using app.EntityModel.AppModels.EmployeeModels;

namespace app.EntityModel.AppModels.AssetModels;

public class AssetTransfer : BaseEntity
{

    public string TransferNo { get; set; }
    public DateTime Date { get; set; }
    public long FromStoreId { get; set; }
    public BusinessCenter FromStore { get; set; }
    public long ToStoreId { get; set; }
    public BusinessCenter ToStore { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; } // AssetTransferStatusEnum
}

