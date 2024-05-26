namespace app.EntityModel.AppModels.SalesModels
{
    public class SalesProductDetail : BaseEntity
    {
        public long SalesOrderDetailsId { get; set; }
        public SalesOrderDetail SalesOrderDetails { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public bool IsForService { get; set; }
    }
}
