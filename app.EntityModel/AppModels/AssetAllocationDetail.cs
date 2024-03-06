﻿namespace app.EntityModel.AppModels
{
    public class AssetAllocationDetail : BaseEntity
    {
        public long AssetAllocationId { get; set; }
        public AssetAllocation AssetAllocation { get; set; }
        public long? ProductId { get; set; }
        public Product Product { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
