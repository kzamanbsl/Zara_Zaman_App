namespace app.Services.CompanyServices
{
    public interface ICompanyService
    {
      
        Task<bool> AddRecord(CompanyViewModel vm);
        Task<bool> UpdateRecord(CompanyViewModel vm);
        Task<CompanyViewModel> GetRecordById(long id);
        Task<CompanyViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
