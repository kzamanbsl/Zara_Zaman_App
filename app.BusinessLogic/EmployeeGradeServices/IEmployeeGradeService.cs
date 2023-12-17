namespace app.Services.EmployeeGradeServices
{
    public interface IEmployeeGradeService
    {
       
        Task<bool> AddRecord(EmployeeGradeViewModel vm);
        Task<bool> UpdateRecord(EmployeeGradeViewModel vm);
        Task<EmployeeGradeViewModel> GetRecordById(long id);
        Task<EmployeeGradeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
        
    }
}
