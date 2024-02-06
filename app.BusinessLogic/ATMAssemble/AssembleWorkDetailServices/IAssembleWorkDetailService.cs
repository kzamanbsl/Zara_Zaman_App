namespace app.Services.ATMAssemble.AssembleWorkDetailServices
{
    public interface IAssembleWorkDetailService
    {

        Task<bool> AddRecord(AssembleWorkDetailViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkDetailViewModel vm);
        Task<AssembleWorkDetailViewModel> GetRecordById(long id);
        Task<AssembleWorkDetailViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
