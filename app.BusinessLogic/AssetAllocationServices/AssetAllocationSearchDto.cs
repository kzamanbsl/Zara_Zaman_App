using app.EntityModel.DataTableSearchModels;
using app.Utility;
using System.ComponentModel;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationSearchDto : BaseDataTableSearch
    {
        [DisplayName("Allocation No")]
        public string AllocationNo { get; set; }

        [DisplayName("Allocation Date")]
        public DateTime Date { get; set; }

        [DisplayName("Employee Name")]
        public long? EmployeeId { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Department Name")]
        public long? DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [DisplayName("Status")]
        public string StatusName => GlobalVariable.GetEnumDescription((AssetAllocationStatusEnum)StatusId);

        public string Description { get; set; }

      
    }
}
