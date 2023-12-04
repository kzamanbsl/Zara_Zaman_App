namespace app.Services.DropDownServices
{
    public interface IDropDownService
    {
        Task<IEnumerable<DropDownViewModel>> CompanyList();
    }
}
