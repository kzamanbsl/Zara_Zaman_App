using app.EntityModel.AppModels.ProductModels;

namespace app.EntityModel.AppModels.SalesModels
{
    public class SalesOrderDetail : BaseEntity
    {
        public long SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public int SalesQty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
        //public decimal Discount { get; set; }
        //public bool IsForService { get; set; }
        public string Remarks { get; set; }

    }
}
