namespace app.Services.SalesTermsAndConditonServices
{
    public interface ISalesTermsAndConditionService
    {
        
        Task<bool> AddRecord(SalesTermsAndConditionViewModel vm);
        Task<bool> UpdateRecord(SalesTermsAndConditionViewModel vm);
        Task<SalesTermsAndConditionViewModel> GetRecordById(long id);
        Task<SalesTermsAndConditionViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);

    }
}
