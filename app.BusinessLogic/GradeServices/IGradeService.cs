namespace app.Services.GradeServices
{
    public interface IGradeService
    {
        Task<GradeViewModel> GetAllRecord();
        Task<int> AddRecord(GradeViewModel model);
        Task<int> UpdateRecord(GradeViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<GradeViewModel> GetRecordById(long id);
    }
}
