namespace app.Services.DepartmentServices
{
    public interface IDepartmentService
    {
       
        Task<bool> AddRecord(DepartmentViewModel vm);
        Task<bool> UpdateRecord(DepartmentViewModel vm);
        Task<DepartmentViewModel> GetRecordById(long id);
        Task<DepartmentViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}
