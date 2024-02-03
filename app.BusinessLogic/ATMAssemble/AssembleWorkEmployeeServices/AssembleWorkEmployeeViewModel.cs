
using app.Services.ATMAssemble.AssembleWorkCategoryServices;

namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkEmployeeViewModel : BaseViewModel
    {
        public long AssembleWorkId { get; set; }
        public string AssembleWorkName { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public IEnumerable<AssembleWorkEmployeeViewModel> AssembleWorkEmployeeList { get; set; }
    }
}
