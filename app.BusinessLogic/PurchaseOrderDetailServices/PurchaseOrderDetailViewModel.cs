using app.EntityModel.AppModels;
using System.ComponentModel.DataAnnotations;

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
        public decimal SalePrice { get; set; }
        public double PurchaseQty { get; set; }
        //public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
