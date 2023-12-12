namespace app.Services.DropdownServices
{
    public interface IDropdownService
    {
        Task<IEnumerable<DropdownViewModel>> CompanySelectionList();
        Task<IEnumerable<DropdownViewModel>> DesignationSelectionList();
        Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList();
        Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList();
<<<<<<< HEAD
        Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList();
        Task<IEnumerable<DropdownViewModel>> ShiftSelectionList();

=======
        Task<IEnumerable<DropdownViewModel>> CountrySelectionList();
        Task<IEnumerable<DropdownViewModel>> DivisionSelectionList();
        Task<IEnumerable<DropdownViewModel>> DistrictSelectionList(int divisionId =0);
        Task<IEnumerable<DropdownViewModel>> UpazilaSelectionList(int divisionId = 0, int districtsId = 0);
        Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList(long managerId = 0);
>>>>>>> 56ced258b042471195870ed4ca434e75c9e064d4
    }
}
