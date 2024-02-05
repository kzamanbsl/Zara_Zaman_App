using app.EntityModel.AppModels;
using app.Services.PurchaseOrderServices;
using app.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.PurchaseOrderDetailServices
{
    public class PurchaseOrderDetailViewModel : BaseViewModel
    {
        public long PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [Required(ErrorMessage = "Select Product")]
        public long ProductId { get; set; }   
        public string ProductName { get; set; } 
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public string UnitName { get; set; }
        public double Consumption { get; set; }
        public double PurchaseQty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public PurchaseOrderViewModel PurchaseOrderVM { get; set; }
    }
}
