using app.EntityModel.AppModels;
using app.EntityModel.AppModels.Sales;

namespace app.Services.SalesOrderDetailServices
{
    public class SalesOrderDetailViewModel : BaseViewModel
    {
        public long SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public string UnitName { get; set; }
        public int SalesQty { get; set; }
        public decimal SalesPrice { get; set; }        
        public decimal TotalAmount { get; set; }
        //public decimal Discount { get; set; }
        //public DateTime? WarrantyFormDate { get; set; }
        //public DateTime? WarrantyToDate { get; set; }
        //public string[] SerialNo { get; set; }
        //public string[] ModelNo { get; set; }
        //public bool[] IsForService { get; set; }
        public string Remarks { get; set; }
        //public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        //public int ActionId { get; set; } = 1;
        public SalesOrderDetailViewModel SalesOrderVM { get; set; }
    }
}
