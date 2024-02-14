namespace app.Services.ServiceCenterServices
{
    public interface IServiceCenterService
    {
       
        Task<bool> AddRecord(ServiceCenterViewModel vm);
        Task<bool> UpdateRecord(ServiceCenterViewModel vm);
        Task<ServiceCenterViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<ServiceCenterViewModel> GetAllRecord();
    }
}
