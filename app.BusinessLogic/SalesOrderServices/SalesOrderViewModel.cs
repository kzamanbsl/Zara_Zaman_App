﻿using app.EntityModel.AppModels;
using app.Services.SalesOrderDetailServices;
using app.Services.SalesProductDetailServices;
using app.Utility;

namespace app.Services.SalesOrderServices
{
    public class SalesOrderViewModel : BaseViewModel
    {
        public string OrderNo { get; set; }
        public DateTime SalesDate { get; set; }
        public long StorehouseId { get; set; }
        public BusinessCenter Storehouse { get; set; }
        public string StoreName { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNo { get; set; }
        public decimal OverallDiscount { get; set; }
        public string Description { get; set; }
        public long TermsAndConditionId { get; set; }
        public string TermsAndCondition { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public int OrderStatusId { get; set; } //SalesOrderStatusEnum
        public string OrderStatusName { get; set; }
        public int PaymentStatusId { get; set; } //PaymentStatusEnum
        public string PaymentStatusName { get; set; }
        public double TotalAmount { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public SalesOrderDetailViewModel SalesOrderDetailVM { get; set; }       
        public SalesProductDetailViewModel SalesProductDetailVM { get; set; }       
        public IEnumerable<SalesOrderViewModel> SalesOrderList { get; set; }
        public IEnumerable<SalesOrderDetailViewModel> SalesOrderDetailsList { get; set; }
    }
}
