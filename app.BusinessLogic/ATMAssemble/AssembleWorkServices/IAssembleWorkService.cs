namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public interface IAssembleWorkService
    {

        Task<bool> AddRecord(AssembleWorkViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkViewModel vm);
        Task<AssembleWorkViewModel> GetRecordById(long id);
        Task<AssembleWorkViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
