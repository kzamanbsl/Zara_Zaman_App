namespace app.EntityModel.AppModels
{
    public class PurchaseOrderDetail : BaseEntity
    {
        public long PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public double Consumption { get; set; }
        public double PurchaseQty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
