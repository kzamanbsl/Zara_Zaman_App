namespace app.Services.DropdownServices
{
    public interface IDropdownService
    {
        Task<IEnumerable<DropdownViewModel>> CompanySelectionList();
        Task<IEnumerable<DropdownViewModel>> DesignatinSelectionList();
        Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList();
    }
}
