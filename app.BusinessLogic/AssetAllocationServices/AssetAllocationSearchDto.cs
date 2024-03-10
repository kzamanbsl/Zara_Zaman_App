using app.EntityModel.AppModels;
using app.EntityModel.DataTableSearchModels;
using app.Services.AssetAllocationDetailServices;
using app.Services.PurchaseOrderDetailServices;
using app.Utility;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Employee Employee { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Department Name")]
        public long? DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public Department Department { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [DisplayName("Status")]
        public int AssetAllocationStatusId { get; set; }

        [DisplayName("Status")]
        public string AssetAllocationStatusName { get; set; }

        public string Remarks { get; set; }
        public int ActionId { get; set; } = 1;
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        
        public AssetAllocationDetailViewModel AssetAllocationDetailVM { get; set; } 
      
    }
}
