using app.EntityModel.AppModels.EmployeeModels;

namespace app.EntityModel.AppModels.AssetModels;

public class AssetAllocation : BaseEntity
{

    public string AllocationNo { get; set; }
    public DateTime Date { get; set; }
    public long? EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public long? DepartmentId { get; set; }
    public Department Department { get; set; }
    public long StorehouseId { get; set; }
    public BusinessCenter Storehouse { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }//AssetAllocationStatusEnum
}

