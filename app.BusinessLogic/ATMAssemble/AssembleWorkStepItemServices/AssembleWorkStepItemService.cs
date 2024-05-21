using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ATMAssemble.AssembleWorkStepItemServices
{
    public class AssembleWorkStepItemService : IAssembleWorkStepItemService
    {
        private readonly IEntityRepository<AssembleWorkStepItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkStepItemService(IEntityRepository<AssembleWorkStepItem> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkStepItemViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStepItem data = new AssembleWorkStepItem();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                data.AssembleWorkStepId = viewModel.AssembleWorkStepId;
                var response = await _iEntityRepository.AddAsync(data);
                viewModel.Id = response.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRecord(AssembleWorkStepItemViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
                result.Name = viewModel.Name;
                result.Description = viewModel.Description;
                result.AssembleWorkStepId = viewModel.AssembleWorkStepId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkStepItemViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkStepItemViewModel model = new AssembleWorkStepItemViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkStepId = result.AssembleWorkStepId;
            model.AssembleWorkStepName = result.AssembleWorkStep?.Name;
            return model;
        }

        public async Task<AssembleWorkStepItemViewModel> GetAllRecord()
        {
            AssembleWorkStepItemViewModel model = new AssembleWorkStepItemViewModel();
            model.AssembleWorkStepItemList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStepItem
                                                                   where t1.IsActive == true
                                                                   select new AssembleWorkStepItemViewModel
                                                                   {
                                                                       Id = t1.Id,
                                                                       Name = t1.Name,
                                                                       Description = t1.Description,
                                                                       AssembleWorkStepId = t1.AssembleWorkStepId,
                                                                       AssembleWorkStepName = t1.AssembleWorkStep.Name,
                                                                       AssembleWorkCategoryId = t1.AssembleWorkStep.AssembleWorkCategory.Id,
                                                                       AssembleWorkCategoryName = t1.AssembleWorkStep.AssembleWorkCategory.Name,
                                                                   }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<AssembleWorkStepItemSearchDto>> SearchAsync(DataTablePagination<AssembleWorkStepItemSearchDto> searchDto)
        {
            var searchResult = _dbContext.AssembleWorkStepItem.Include(c => c.AssembleWorkStep).ThenInclude(c => c.AssembleWorkCategory).Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (searchModel?.AssembleWorkStepId is > 0)
            {
                searchResult = searchResult.Where(c => c.AssembleWorkStepId == searchModel.AssembleWorkStepId);
            }
            if (searchModel?.AssembleWorkCategoryId is > 0)
            {
                searchResult = searchResult.Where(c => c.AssembleWorkStep.AssembleWorkCategoryId == searchModel.AssembleWorkCategoryId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.AssembleWorkStep.Name.ToLower().Contains(filter)
                    || c.AssembleWorkStep.AssembleWorkCategory.Name.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<AssembleWorkStepItem> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssembleWorkStepItemSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                AssembleWorkStepId = c.AssembleWorkStepId,
                AssembleWorkStepName = c.AssembleWorkStep?.Name,
                AssembleWorkCategoryId = c.AssembleWorkStep.AssembleWorkCategoryId,
                AssembleWorkCategoryName = c.AssembleWorkStep?.AssembleWorkCategory?.Name

            }).ToList();

            return searchDto;
        }
    }
}