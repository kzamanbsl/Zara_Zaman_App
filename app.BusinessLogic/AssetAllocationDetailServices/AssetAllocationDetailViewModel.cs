using app.EntityModel.AppModels;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using System.ComponentModel.DataAnnotations;

namespace app.Services.AssetAllocationDetailServices
{
    public class AssetAllocationDetailViewModel : BaseViewModel
    {
        public long AssetAllocationId { get; set; }
        public AssetAllocation AssetAllocation { get; set; }
        public string AssetAllocationName { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeName { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string DepartmentName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public AssetPurchaseOrderViewModel AssetPurchaseOrderVM { get; set; }
    }
}
