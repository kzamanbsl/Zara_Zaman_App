namespace app.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<DepartmentViewModel> GetAllRecord();
        Task<int> AddRecord(DepartmentViewModel model);
        Task<int> UpdateRecord(DepartmentViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<DepartmentViewModel> GetRecordById(long id);
    }
}
