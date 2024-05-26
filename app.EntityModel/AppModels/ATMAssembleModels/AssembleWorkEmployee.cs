using app.EntityModel.AppModels.EmployeeModels;

namespace app.EntityModel.AppModels.ATMAssembleModels;

public class AssembleWorkEmployee : BaseEntity
{
    public long AssembleWorkId { get; set; }
    public long EmployeeId { get; set; }

    public AssembleWork AssembleWork { get; set; }
    public Employee Employee { get; set; }
}
