using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Services.ATMAssemble.AssembleWorkStepServices;
using app.Services.EmployeeServices;
using app.Utility;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkViewModel : BaseViewModel
    {
        public long AssembleWorkCategoryId { get; set; }
        public string AssembleWorkCategoryName { get; set; }
        public DateTime AssembleDate { get; set; }
        public int AssembleTarget { get; set; } // False Prop
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName => GlobalVariable.GetEnumDescription((AssembleWorkStatusEnum)StatusId);

        public long[] EmployeeIds { get; set; }

        public IEnumerable<AssembleWorkViewModel> AssembleWorkList { get; set; }
        public List<AssembleWorkDetailViewModel> DetailList { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
        public IEnumerable<AssembleWorkCategoryViewModel> AssembleWorkCategory { get; set; }
        public IEnumerable<AssembleWorkStepViewModel> AssembleWorkStep { get; set; }
        public IEnumerable<AssembleWorkStepItemViewModel> AssembleWorkStepItem { get; set; }
        public IEnumerable<AssembleWorkEmployeeViewModel> AssembleWorkEmployee { get; set; }
    }
}
