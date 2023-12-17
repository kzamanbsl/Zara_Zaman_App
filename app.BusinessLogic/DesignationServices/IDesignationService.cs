namespace app.Services.DesignationServices
{
    public interface IDesignationService
    {
      
        Task<bool> AddRecord(DesignationViewModel vm);
        Task<bool> UpdateRecord(DesignationViewModel vm);
        Task<DesignationViewModel> GetRecordById(long id);
        Task<DesignationViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}
