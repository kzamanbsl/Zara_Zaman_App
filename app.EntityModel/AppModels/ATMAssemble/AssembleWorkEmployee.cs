using app.EntityModel.AppModels.EmployeeManage;

namespace app.EntityModel.AppModels.ATMAssemble;

public class AssembleWorkEmployee : BaseEntity
{
    public long AssembleWorkId { get; set; }
    public long EmployeeId { get; set; }

    public AssembleWork AssembleWork { get; set; }
    public Employee Employee { get; set; }
}
