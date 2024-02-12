using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class SalesOrder : BaseEntity
    {
        public string SalesOrderNo { get; set; }
        public int SalesStatusId { get; set; }
        public long CustomerId { get; set; } 
        public DateTime SalesDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string TermsAndCondition { get; set; }
        public string Description { get; set; }
        public string PaymentType { get; set; }
        public long? StorehouseId { get; set; }
        public BusinessCenter Storehouse { get; set; }
    }
}
