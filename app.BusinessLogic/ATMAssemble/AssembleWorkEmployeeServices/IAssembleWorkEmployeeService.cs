namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public interface IAssembleWorkEmployeeService
    {

        Task<bool> AddRecord(AssembleWorkEmployeeViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkEmployeeViewModel vm);
        Task<AssembleWorkEmployeeViewModel> GetRecordById(long id);
        Task<AssembleWorkEmployeeViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
