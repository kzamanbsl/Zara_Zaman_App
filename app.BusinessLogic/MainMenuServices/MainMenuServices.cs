using app.EntityModel.CoreModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.UserServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.MainMenuServices
{
    public class MainMenuService : IMainMenuService
    {
        private readonly InventoryDbContext _dbContext;
        private readonly IEntityRepository<MainMenu> _entityRepository;
        public MainMenuService(InventoryDbContext dbContext, IEntityRepository<MainMenu> entityRepository)
        {
            _dbContext = dbContext;
           _entityRepository = entityRepository;
        }
        public async Task<bool> AddRecord(MainMenuViewModel vm)
        {
            var getItem = _entityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == vm.Name.Trim());
            if (getItem == null)
            {
                MainMenu menu = new MainMenu();
                menu.Name = vm.Name;
                menu.Icon = vm.Icon;
                menu.OrderNo = vm.OrderNo;
                var result = await _entityRepository.AddAsync(menu);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> UpdateRecord(MainMenuViewModel vm)
        {
            var checkMenu = _entityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == vm.Name && f.Id != vm.Id);
            if (checkMenu == null)
            {
                var menu = await _entityRepository.GetByIdAsync(vm.Id);
                menu.Name = vm.Name;
                menu.Icon = vm.Icon;
                menu.OrderNo = vm.OrderNo;
                menu.IsActive = vm.IsActive;
                var result = await _entityRepository.UpdateAsync(menu);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
       
        public async Task<MainMenuViewModel> GetRecordById(long id)
        {
            MainMenu menu = await _entityRepository.GetByIdAsync(id);
            MainMenuViewModel model = new MainMenuViewModel();
            model.Id = menu.Id;
            model.Name = menu.Name;
            model.OrderNo = menu.OrderNo;
            model.Icon = menu.Icon;
            model.IsActive = menu.IsActive;
            return model;
        }
        
        public async Task<bool> DeleteRecord(long id)
        {
            var getItem = await _entityRepository.GetByIdAsync(id);
            if (getItem != null)
            {
                getItem.IsActive = false;
                var result = await _entityRepository.UpdateAsync(getItem);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<List<MainMenu>> GetAllRecord()
        {
            List<MainMenu> getItem = await _entityRepository.AllIQueryableAsync().OrderBy(d => d.OrderNo).ToListAsync();
            return getItem;
        }

        public async Task<DataTablePagination<MainMenuSearchDto>> SearchAsync(DataTablePagination<MainMenuSearchDto> searchDto)
        {
            var searchResult = _dbContext.MainMenu.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Icon.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<MainMenu> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new MainMenuSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                Icon = c.Icon,
                OrderNo = c.OrderNo,
                IsActive = c.IsActive,
            }).ToList();

            return searchDto;
        }

    }
}
