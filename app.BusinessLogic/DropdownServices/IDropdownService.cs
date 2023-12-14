namespace app.Services.DropdownServices
{
    public interface IDropdownService
    {
        Task<IEnumerable<DropdownViewModel>> CompanySelectionList();
        Task<IEnumerable<DropdownViewModel>> DesignationSelectionList();
        Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList();
        Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList();
        //Task<IEnumerable<DropdownViewModel>> AttendanceSelectionList(long managerId = 0);
        Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList(long managerId = 0);
        Task<IEnumerable<DropdownViewModel>> ShiftSelectionList();
        Task<IEnumerable<DropdownViewModel>> CountrySelectionList();
        Task<IEnumerable<DropdownViewModel>> DivisionSelectionList();
        Task<IEnumerable<DropdownViewModel>> DistrictSelectionList(int divisionId = 0);
        Task<IEnumerable<DropdownViewModel>> UpazilaSelectionList(int divisionId = 0, int districtsId = 0);
        Task<IEnumerable<DropdownViewModel>> BloodGroupSelectionList();
        Task<IEnumerable<DropdownViewModel>> MaritalStatusSelectionList();
        Task<IEnumerable<DropdownViewModel>> GenderSelectionList();
        Task<IEnumerable<DropdownViewModel>> ReligionSelectionList();
        Task<IEnumerable<DropdownViewModel>> EmployeeCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> ServiceTypeSelectionList();
        Task<IEnumerable<DropdownViewModel>> JobStatusSelectionList();
        Task<IEnumerable<DropdownViewModel>> OfficeTypeSelectionList();
        Task<IEnumerable<DropdownViewModel>> GradeSelectionList();

    }
}
