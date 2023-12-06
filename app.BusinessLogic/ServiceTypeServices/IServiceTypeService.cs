namespace app.Services.ServiceTypeServices
{
    public interface IServiceTypeService
    {
        Task<ServiceTypeViewModel> GetAllRecord();
        Task<int> AddRecord(ServiceTypeViewModel model);
        Task<int> UpdateRecord(ServiceTypeViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<ServiceTypeViewModel> GetRecordById(long id);
    }
}
