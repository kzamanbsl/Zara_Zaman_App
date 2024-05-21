using app.EntityModel.DataTableSearchModels;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.EmployeeServices;
using app.Utility;
using System.ComponentModel;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkSearchDto : BaseDataTableSearch
    {
        [DisplayName("Work Category")]
        public long AssembleWorkCategoryId { get; set; }

        [DisplayName("Assemble Work Category")]
        public string AssembleWorkCategoryName { get; set; }

        [DisplayName("Assemble Date")]
        public DateTime AssembleDate { get; set; }
        public int AssembleTarget { get; set; } // False Prop
        public string Description { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [DisplayName("Status")]
        public string StatusName => GlobalVariable.GetEnumDescription((AssembleWorkStatusEnum)StatusId);

        public long[] EmployeeIds { get; set; }
        public List<AssembleWorkDetailViewModel> DetailList { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
    }
}
