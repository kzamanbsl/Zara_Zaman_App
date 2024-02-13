namespace app.EntityModel.AppModels
{
    public class SalesOrder : BaseEntity
    {
        public string OrderNo { get; set; }
        public DateTime SalesDate { get; set; }
        public long StorehouseId { get; set; }
        public BusinessCenter Storehouse { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal OverallDiscount { get; set; }
        public string Description { get; set; }
        public string TermsAndCondition { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
     
        public int OrderStatusId { get; set; } //SalesOrderStatusEnum
        public int PaymentStatusId { get; set; } //PaymentStatusEnum

    }
}
