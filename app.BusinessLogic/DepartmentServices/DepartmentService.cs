using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.DesignationServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IEntityRepository<Department> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DepartmentService(IEntityRepository<Department> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(DepartmentViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Department com = new Department();
                com.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(DepartmentViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<DepartmentViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            DepartmentViewModel model = new DepartmentViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<DepartmentViewModel> GetAllRecord()
        {
            DepartmentViewModel model = new DepartmentViewModel();
            model.DepartmentList = await Task.Run(() => (from t1 in _dbContext.Department
                                                                where t1.IsActive == true
                                                                select new DepartmentViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<DepartmentSearchDto>> SearchAsync(DataTablePagination<DepartmentSearchDto> searchDto)
        {
            var searchResult = _dbContext.Department.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Department> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new DepartmentSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,

            }).ToList();

            return searchDto;
        }
    }
}
