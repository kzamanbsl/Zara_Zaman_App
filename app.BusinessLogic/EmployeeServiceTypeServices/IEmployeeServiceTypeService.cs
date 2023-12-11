namespace app.Services.EmployeeServiceTypeServices
{
    public interface IEmployeeServiceTypeService
    {
        Task<EmployeeServiceTypeViewModel> GetAllRecord();
        Task<int> AddRecord(EmployeeServiceTypeViewModel model);
        Task<int> UpdateRecord(EmployeeServiceTypeViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<EmployeeServiceTypeViewModel> GetRecordById(long id);
    }
}
