namespace app.EntityModel.AppModels
{
    public class SalesProductDetail : BaseEntity
    {
        public long SalesOrderDetailsId { get; set; }
        public SalesOrderDetails SalesOrderDetails { get; set; }
        public DateTime? WarrantyFormDate { get; set; }
        public DateTime? WarrantyToDate { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public bool IsForService { get; set; }
    }
}
