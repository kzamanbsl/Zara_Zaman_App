namespace app.Services.StorehouseServices
{
    public interface IStorehouseService
    {
       
        Task<bool> AddRecord(StorehouseViewModel vm);
        Task<bool> UpdateRecord(StorehouseViewModel vm);

        Task<StorehouseViewModel> GetRecordById(long id);
        Task<StorehouseViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
