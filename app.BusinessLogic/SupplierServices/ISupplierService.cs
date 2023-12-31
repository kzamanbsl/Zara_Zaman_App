namespace app.Services.SupplierServices
{
    public interface ISupplierService
    {
       
        Task<bool> AddRecord(SupplierViewModel vm);
        Task<bool> UpdateRecord(SupplierViewModel vm);
        Task<SupplierViewModel> GetRecordById(long id);
        Task<SupplierViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
