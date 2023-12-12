namespace app.Services.DropdownServices
{
    public interface IDropdownService
    {
        Task<IEnumerable<DropdownViewModel>> CompanySelectionList();
        Task<IEnumerable<DropdownViewModel>> DesignatinSelectionList();
        Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList();
        Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList();
<<<<<<< HEAD
        Task<IEnumerable<DropdownViewModel>> LeaveApplicationSelectionList();
=======
        Task<IEnumerable<DropdownViewModel>> CountrySelectionList();
        Task<IEnumerable<DropdownViewModel>> DivisionSelectionList();
        Task<IEnumerable<DropdownViewModel>> DistrictSelectionList(int divisionId =0);
        Task<IEnumerable<DropdownViewModel>> UpazilaSelectionList(int divisionId = 0, int districtsId = 0);
>>>>>>> 7b3b8590839097205f65afa85b52c27a4a390d32

    }
}
