namespace app.Services.DropdownServices
{
    public interface IDropdownService
    {
        Task<IEnumerable<DropdownViewModel>> EmptySelectionList();
        Task<IEnumerable<DropdownViewModel>> CompanySelectionList();
        Task<IEnumerable<DropdownViewModel>> DepartmentSelectionList();
        Task<IEnumerable<DropdownViewModel>> DesignationSelectionList();
        Task<IEnumerable<DropdownViewModel>> ShiftSelectionList();
        Task<IEnumerable<DropdownViewModel>> LeaveCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> EmployeeSelectionList(long managerId = 0);
       
        Task<IEnumerable<DropdownViewModel>> CountrySelectionList();
        Task<IEnumerable<DropdownViewModel>> DivisionSelectionList();
        Task<IEnumerable<DropdownViewModel>> DistrictSelectionList(int divisionId = 0);
        Task<IEnumerable<DropdownViewModel>> UpazilaSelectionList(int divisionId = 0, int districtsId = 0);
        Task<IEnumerable<DropdownViewModel>> BloodGroupSelectionList();
        Task<IEnumerable<DropdownViewModel>> MaritalStatusSelectionList();
        Task<IEnumerable<DropdownViewModel>> GenderSelectionList();
        Task<IEnumerable<DropdownViewModel>> ReligionSelectionList();
        Task<IEnumerable<DropdownViewModel>> EmployeeCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> EmployeeServiceTypeSelectionList();
        Task<IEnumerable<DropdownViewModel>> OfficeTypeSelectionList();
        Task<IEnumerable<DropdownViewModel>> EmployeeGradeSelectionList();
        Task<IEnumerable<DropdownViewModel>> JobStatusSelectionList();
        Task<IEnumerable<DropdownViewModel>> UnitSelectionList();
        Task<IEnumerable<DropdownViewModel>> ProductCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> AssetCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> SupplierSelectionList();
        Task<IEnumerable<DropdownViewModel>> CustomerSelectionList();
        Task<IEnumerable<DropdownViewModel>> StorehouseSelectionList();
        Task<IEnumerable<DropdownViewModel>> ProductSelectionList();
        Task<IEnumerable<DropdownViewModel>> AssetSelectionList();
        Task<IEnumerable<DropdownViewModel>> AssembleWorkCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> AssembleWorkStepSelectionList();
        Task<IEnumerable<DropdownViewModel>> TermsAndConditionsSelectionList();
        Task<IEnumerable<DropdownViewModel>> SupplierCategorySelectionList();
        Task<IEnumerable<DropdownViewModel>> BankSelectionList();
        Task<IEnumerable<DropdownViewModel>> BankBranchSelectionList(long? BankId = 0);
    }
}
