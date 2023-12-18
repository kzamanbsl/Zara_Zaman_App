namespace app.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<bool> AddRecord(EmployeeViewModel vm);
        Task<bool> UpdateRecord(EmployeeViewModel vm);
        Task<EmployeeViewModel> GetRecordById(long id);
        Task<EmployeeViewModel> GetAllRecord();
        //Task<bool> DeleteRecord(long id);
        Task<EmployeeViewModel>GetDetailsById(long id);
    }
}
