namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public interface IAssembleWorkStepService
    {
        Task<bool> AddRecord(AssembleWorkStepViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkStepViewModel vm);
        Task<AssembleWorkStepViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkStepViewModel> GetAllRecord();

    }
}
