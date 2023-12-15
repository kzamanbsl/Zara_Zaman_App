namespace app.Services.OfficeTypeServices
{
    public interface IOfficeTypeService
    {
        
        Task<bool> AddRecord(OfficeTypeViewModel vm);
        Task<bool> UpdateRecord(OfficeTypeViewModel vm);
        Task<OfficeTypeViewModel> GetRecordById(long id);
        Task<OfficeTypeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
