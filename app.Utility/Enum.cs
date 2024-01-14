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

    public enum StoreTypeEnum
    {
        Purchase = 1,
        Menufacture       
    }
    public enum PurchaseTypeEnum
    {
        Purchase = 1,
        AssetPurchase
    }


    public enum ProductcategoryTypeEnum
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
}
