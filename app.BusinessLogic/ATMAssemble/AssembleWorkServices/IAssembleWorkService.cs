namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public interface IAssembleWorkService
    {

        Task<bool> AddRecord(AssembleWorkViewModel vm);
        Task<bool> UpdateRecord(AssembleWorkViewModel vm);
        Task<AssembleWorkViewModel> GetRecordById(long id);
        Task<AssembleWorkMainDashboardViewModel> MainDashboard();
        Task<List<AssembleWorkViewModel>> EmployeeDashboard();
        Task<object> MakeStepItemComplete(long assembleWorkId, long assembleWorkDetailId, long assembleWorkCategoryId, long assembleWorkStepId, long assembleWorkStepItemId);
        Task<object> MakeStatusComplete(long assembleWorkId);
        Task<object> MakeStatusFault(long assembleWorkId);
        Task<bool> DeleteRecord(long id);
        Task<AssembleWorkViewModel> GetAllRecord();


    }
}
