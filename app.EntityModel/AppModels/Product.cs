﻿namespace app.EntityModel.AppModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TradePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ProductTypeId { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public long CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public bool HasWarranty { get; set; }
        public bool HasSerialNo { get; set; }
        public bool HasModelNo { get; set; }

    }
}
