namespace app.Services.ServiceCenterServices
{
    public interface IServiceCenterService
    {
       
        Task<bool> AddRecord(ServiceCenterViewModel vm);
        Task<bool> UpdateRecord(ServiceCenterViewModel vm);
        Task<ServiceCenterViewModel> GetRecordById(long id);
        Task<ServiceCenterViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
