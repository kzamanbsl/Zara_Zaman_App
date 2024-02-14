namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public interface IAssembleWorkCategoryService
    {

        Task<bool> AddRecord(AssembleWorkCategoryViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkCategoryViewModel vm);
        Task<AssembleWorkCategoryViewModel> GetRecordById(long id);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkCategoryViewModel> GetAllRecord();

    }
}
