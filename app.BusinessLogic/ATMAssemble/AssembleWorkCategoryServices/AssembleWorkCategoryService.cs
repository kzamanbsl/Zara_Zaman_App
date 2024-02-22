using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.AssetCategoryServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ATMAssemble.AssembleWorkCategoryServices
{
    public class AssembleWorkCategoryService : IAssembleWorkCategoryService
    {
        private readonly IEntityRepository<AssembleWorkCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkCategoryService(IEntityRepository<AssembleWorkCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkCategoryViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkCategory data = new AssembleWorkCategory();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                var response = await _iEntityRepository.AddAsync(data);
                viewModel.Id = response.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRecord(AssembleWorkCategoryViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
                result.Name = viewModel.Name;
                result.Description = viewModel.Description;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<AssembleWorkCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkCategoryViewModel model = new AssembleWorkCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<AssembleWorkCategoryViewModel> GetAllRecord()
        {
            AssembleWorkCategoryViewModel model = new AssembleWorkCategoryViewModel();
            model.AssembleWorkCategoryList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkCategory
                                                                   where t1.IsActive == true
                                                                   select new AssembleWorkCategoryViewModel
                                                                   {
                                                                       Id = t1.Id,
                                                                       Name = t1.Name,
                                                                       Description = t1.Description,
                                                                   }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<AssembleWorkCategorySearchDto>> SearchAsync(DataTablePagination<AssembleWorkCategorySearchDto> searchDto)
        {
            var searchResult = _dbContext.AssembleWorkCategory.AsNoTracking();

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

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<AssembleWorkCategory> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssembleWorkCategorySearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,

            }).ToList();

            return searchDto;
        }
    }

}
