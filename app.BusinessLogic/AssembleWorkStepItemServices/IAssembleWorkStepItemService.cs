namespace app.Services.AssembleWorkStepItemServices
{
    public interface IAssembleWorkStepItemService
    {
       
        Task<bool> AddRecord(AssembleWorkStepItemViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkStepItemViewModel vm);
        Task<AssembleWorkStepItemViewModel> GetRecordById(long id);
        Task<AssembleWorkStepItemViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
       
    }
}
