namespace app.Services.LeaveCategoryServices
{
    public interface ILeaveCategoryService
    {
       
        Task<bool> AddRecord(LeaveCategoryViewModel vm);
        Task<bool> UpdateRecord(LeaveCategoryViewModel vm);
        Task<LeaveCategoryViewModel> GetRecordById(long id);
        Task<LeaveCategoryViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
      
    }
}
