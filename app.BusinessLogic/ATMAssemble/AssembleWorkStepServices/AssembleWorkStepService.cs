using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ATMAssemble.AssembleWorkStepServices
{
    public class AssembleWorkStepService : IAssembleWorkStepService
    {
        private readonly IEntityRepository<AssembleWorkStep> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public AssembleWorkStepService(IEntityRepository<AssembleWorkStep> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(AssembleWorkStepViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.AssembleWorkCategoryId==viewModel.AssembleWorkCategoryId && f.IsActive == true);
            if (checkName == null)
            {
                AssembleWorkStep data = new AssembleWorkStep();
                data.Name = viewModel.Name;
                data.Description = viewModel.Description;
                data.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
                var res = await _iEntityRepository.AddAsync(data);
                viewModel.Id = res.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRecord(AssembleWorkStepViewModel viewModel)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.AssembleWorkCategoryId == viewModel.AssembleWorkCategoryId && f.Id != viewModel.Id && f.IsActive == true);

            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
                result.Name = viewModel.Name;
                result.Description = viewModel.Description;
                result.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AssembleWorkStepViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkStepViewModel model = new AssembleWorkStepViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkCategoryId = result.AssembleWorkCategoryId;
            model.AssembleWorkCategoryName = result.AssembleWorkCategory?.Name;
            return model;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkStepViewModel> GetAllRecord()
        {
            AssembleWorkStepViewModel model = new AssembleWorkStepViewModel();
            model.AssembleWorkStepList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStep
                                                               where t1.IsActive == true
                                                               select new AssembleWorkStepViewModel
                                                               {
                                                                   Id = t1.Id,
                                                                   Name = t1.Name,
                                                                   Description = t1.Description,
                                                                   AssembleWorkCategoryId = t1.AssembleWorkCategoryId,
                                                                   AssembleWorkCategoryName = t1.AssembleWorkCategory.Name,
                                                               }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<AssembleWorkStepSearchDto>> SearchAsync(DataTablePagination<AssembleWorkStepSearchDto> searchDto)
        {
            var searchResult = _dbContext.AssembleWorkStep.Include(c=>c.AssembleWorkCategory).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.AssembleWorkCategoryId is > 0)
            {
                searchResult = searchResult.Where(c => c.AssembleWorkCategoryId == searchModel.AssembleWorkCategoryId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.AssembleWorkCategory.Name.ToLower().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<AssembleWorkStep> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssembleWorkStepSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                AssembleWorkCategoryId = c.AssembleWorkCategoryId,
                AssembleWorkCategoryName = c.AssembleWorkCategory.Name,
                Description = c.Description,

            }).ToList();

            return searchDto;
        }

    }
}