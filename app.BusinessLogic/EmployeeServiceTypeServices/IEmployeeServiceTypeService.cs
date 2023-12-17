namespace app.Services.EmployeeServiceTypeServices
{
    public interface IEmployeeServiceTypeService
    {
       
        Task<bool> AddRecord(EmployeeServiceTypeViewModel vm);
        Task<bool> UpdateRecord(EmployeeServiceTypeViewModel vm);
        Task<EmployeeServiceTypeViewModel> GetRecordById(long id);
        Task<EmployeeServiceTypeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
        
    }
}
