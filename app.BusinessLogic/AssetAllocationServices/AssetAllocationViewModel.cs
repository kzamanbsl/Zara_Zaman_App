using app.EntityModel.AppModels.EmployeeModels;
using app.Services.AssetAllocationDetailServices;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetAllocationServices
{
    public class AssetAllocationViewModel : BaseViewModel
    {
        
        public string AllocationNo { get; set; }
        public int StatusId { get; set; }
        public string StatusName => GlobalVariable.GetEnumDescription((AssetAllocationStatusEnum)StatusId);

        public long? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;

        public AssetAllocationDetailViewModel AssetAllocationDetailVm { get; set; } 
        public IEnumerable<AssetAllocationViewModel> AssetAllocationList { get; set; }
        public IEnumerable<AssetAllocationDetailViewModel> AssetAllocationDetailsList { get; set; }
    }
}
