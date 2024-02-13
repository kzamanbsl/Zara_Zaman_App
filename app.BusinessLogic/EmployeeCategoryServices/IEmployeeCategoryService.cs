namespace app.Services.EmployeeCategoryServices
{
    public interface IEmployeeCategoryService
    {
        Task<bool> AddRecord(EmployeeCategoryViewModel vm);
        Task<bool> UpdateRecord(EmployeeCategoryViewModel vm);
        Task<EmployeeCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeCategoryViewModel> GetAllRecord();
    }
}
