using app.EntityModel.AppModels.Office;
using app.EntityModel.AppModels.EmployeeManage;

namespace app.EntityModel.AppModels.AssetManage;

public class AssetAllocation : BaseEntity
{

    public string OrderNo { get; set; }
    public int AssetAllocationStatusId { get; set; }
    public long? EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public long? DepartmentId { get; set; }
    public Department Department { get; set; }
    public DateTime Date { get; set; }
    public string Remarks { get; set; }

}

