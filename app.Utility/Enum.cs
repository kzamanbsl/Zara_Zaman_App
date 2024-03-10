namespace app.Utility
{
    public enum DropdownTypeEnum
    {
        BloodGroup = 1,
        MaritalStatus,
        Gender,
        Religion 
    }

    public enum LeaveApplicationStatusEnum
    {
        Applied = 1,
        Confirm,
        Approve,
        Reject
    }

    public enum PurchaseOrderStatusEnum
    {
        Draft = 1,
        Confirm,
        Submitted,
        Approve,
        Receive,
        Hold,
        Reject
    }
    public enum AssetAllocationStatusEnum
    {
        Draft = 1,
        Confirm,
        Approve,
        Receive,
        Hold,
        Reject
    }

    public enum StoreTypeEnum
    {
        Purchase = 1,
        Manufacture       
    }

    public enum PurchaseTypeEnum
    {
        Purchase = 1,
        AssetPurchase
    }

    public enum ProductCategoryTypeEnum
    {
        ProductCategory = 1,
        AssetCategory
    }

    public enum ProductTypeEnum
    {
        Product = 1,
        Asset
    }

    public enum ActionEnum
    {
        Add = 1,
        Edit,
        Delete
    }

    public enum BusinessCenterEnum
    {
        Storehouse = 1,
        SaleCenter,
        ServiceCenter
    }

    public enum SalesOrderStatusEnum
    {
        Draft = 1,
        Confirm,
        Approve,
        Receive,
        Hold,
        Reject
    }

    public enum PaymentStatusEnum
    {
        Due = 1,
        Partial,
        Paid,
    }

    public enum AssembleWorkStatusEnum
    {
        Draft = 1,
        Confirm,
        Complete,
        Fault,
        Hold,
        Reject
    }

}
