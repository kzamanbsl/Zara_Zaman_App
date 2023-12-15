namespace app.Services.ServiceTypeServices
{
    public interface IServiceTypeService
    {
       
        Task<bool> AddRecord(ServiceTypeViewModel vm);
        Task<bool> UpdateRecord(ServiceTypeViewModel vm);
        Task<ServiceTypeViewModel> GetRecordById(long id);
        Task<ServiceTypeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}
