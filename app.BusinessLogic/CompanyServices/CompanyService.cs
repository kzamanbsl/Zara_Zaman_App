using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.StorehouseServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

namespace app.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IEntityRepository<Company> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public CompanyService(IEntityRepository<Company> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(CompanyViewModel vm)
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Company model = new Company();
                model.Name = vm.Name;
                var res = await _iEntityRepository.AddAsync(model);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(CompanyViewModel vm)
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
        public async Task<CompanyViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            CompanyViewModel model = new CompanyViewModel();
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
        public async Task<CompanyViewModel> GetAllRecord()
        {
            CompanyViewModel model = new CompanyViewModel();
            model.CompanyList = await Task.Run(() => (from t1 in _dbContext.Company
                                                                where t1.IsActive == true
                                                                select new CompanyViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<CompanySearchDto>> SearchAsync(DataTablePagination<CompanySearchDto> searchDto)
        {
            var searchResult = _dbContext.Company.Where(c => c.IsActive == true).AsNoTracking();

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
            List<Company> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new CompanySearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                
            }).ToList();

            return searchDto;
        }
    }
}
