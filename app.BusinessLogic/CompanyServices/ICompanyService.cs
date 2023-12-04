namespace app.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<CompanyViewModel> GetAllRecord();
        Task<int> AddRecord(CompanyViewModel model);
        Task<int> UpdateRecord(CompanyViewModel model);
        Task<bool> DeleteRecord(long id);
        Task<CompanyViewModel> GetRecordById(long id);
    }
}
