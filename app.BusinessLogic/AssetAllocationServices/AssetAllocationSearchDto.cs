using app.EntityModel.DataTableSearchModels;
using app.Utility;
using System.ComponentModel;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationSearchDto : BaseDataTableSearch
    {
        [DisplayName("Order No")]
        public string OrderNo { get; set; }

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
        public int AssetAllocationStatusId { get; set; }

        [DisplayName("Status")]
        public string AssetAllocationStatusName => GlobalVariable.GetEnumDescription((AssetAllocationStatusEnum)AssetAllocationStatusId);

        public string Remarks { get; set; }

        public int ActionId { get; set; } = 1;
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }

      
    }
}
