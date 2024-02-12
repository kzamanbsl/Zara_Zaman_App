using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class SalesOrderDetails : BaseEntity
    {
        public long SalesOrderId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal SalesQty { get; set; }
        public decimal SalesRate { get; set; }
        public decimal SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
