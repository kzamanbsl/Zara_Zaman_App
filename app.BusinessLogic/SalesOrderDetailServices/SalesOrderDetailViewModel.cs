using app.EntityModel.AppModels;

namespace app.Services.SalesOrderDetailServices
{
    public class SalesOrderDetailViewModel : BaseViewModel
    {
        public long SalesOrderId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal SalesQty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public bool? IsForService { get; set; }
        public string Remarks { get; set; }
    }
}
