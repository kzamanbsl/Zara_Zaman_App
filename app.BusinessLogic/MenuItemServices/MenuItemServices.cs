using app.EntityModel.CoreModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.UserServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.MenuItemServices
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IEntityRepository<MenuItem> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        public MenuItemService(IEntityRepository<MenuItem> iEntityRepository, InventoryDbContext dbContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> AddRecord(MenuItemViewModel vm)
        {
            var getItem = _iEntityRepository.AllIQueryableAsync().AsNoTracking().FirstOrDefault(f => f.Name == vm.Name && f.Action == vm.Action && f.Controller == vm.Controller);
            if (getItem == null)
            {
                MenuItem item = new MenuItem();
                item.Name = vm.Name;
                item.ShortName = vm.ShortName;
                item.Icon = vm.Icon;
                item.MenuId = vm.MenuId;
                item.Action = vm.Action;
                item.Controller = vm.Controller;
                item.OrderNo = vm.OrderNo;
                item.IsMenuShow = vm.IsMenuShow;
                var result = await _iEntityRepository.AddAsync(item);

                return result.Id > 0 ? true : false;

            }
            return false;

        }
        public async Task<bool> UpdateRecord(MenuItemViewModel vm)
        {
            var getItem = _iEntityRepository.AllIQueryableAsync().AsNoTracking().FirstOrDefault(f => f.Name == vm.Name && f.Action == vm.Action && f.Controller == vm.Controller && f.Id != vm.Id);
            if (getItem == null)
            {
                MenuItem item = await _iEntityRepository.GetByIdAsync(vm.Id);
                item.Name = vm.Name;
                item.ShortName = vm.ShortName;
                item.Icon = vm.Icon;
                item.MenuId = vm.MenuId;
                item.Action = vm.Action;
                item.Controller = vm.Controller;
                item.OrderNo = vm.OrderNo;
                //item.IsActive = vm.IsActive;
                item.IsMenuShow = vm.IsMenuShow;
                var result = await _iEntityRepository.UpdateAsync(item);

                return result;

            }
            return false;

        }
        public async Task<MenuItemViewModel> GetRecordById(long id)
        {
            MenuItemViewModel model = new MenuItemViewModel();
            MenuItem item = await _iEntityRepository.GetByIdAsync(id);
            model.Name = item.Name;
            model.ShortName = item.ShortName;
            model.OrderNo = item.OrderNo;
            model.Controller = item.Controller;
            model.Action = item.Action;
            model.Icon = item.Icon;
            model.MenuId = item.MenuId;
            model.IsActive = item.IsActive;
            model.IsMenuShow = item.IsMenuShow;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var getItem = await _iEntityRepository.GetByIdAsync(id);
            if (getItem != null)
            {
                getItem.IsActive = false;
                var result = await _iEntityRepository.UpdateAsync(getItem);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<bool> MenuShowSideBar(long id)
        {
            var getItem = await _iEntityRepository.GetByIdAsync(id);
            if (getItem != null)
            {
                getItem.IsMenuShow = false;
                var result = await _iEntityRepository.UpdateAsync(getItem);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<MenuItemViewModel> GetAllRecord()
        {
            MenuItemViewModel model = new MenuItemViewModel();
            model.DataList = await Task.Run(() => (from t1 in _dbContext.MenuItem
                                                   join t2 in _dbContext.MainMenu on t1.MenuId equals t2.Id
                                                   select new MenuItemViewModel
                                                   {
                                                       Id = t1.Id,
                                                       OrderNo = t1.OrderNo,
                                                       Name = t1.Name,
                                                       ShortName = t1.ShortName,
                                                       Icon = t1.Icon,
                                                       Action = t1.Action,
                                                       Controller = t1.Controller,
                                                       MenuId = t1.MenuId,
                                                       MenuName = t2.Name,
                                                       IsActive = t1.IsActive,
                                                       IsMenuShow = t1.IsMenuShow,
                                                   }).OrderByDescending(x => x.OrderNo).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<MenuItemSearchDto>> SearchAsync(DataTablePagination<MenuItemSearchDto> searchDto)
        {
            var searchResult = _dbContext.MenuItem.Include(c => c.Menu).Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.MenuId is > 0)
            {
                searchResult = searchResult.Where(c => c.MenuId == searchModel.MenuId);
            }
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.Menu.Name.ToLower().Contains(filter)
                    || c.ShortName.ToLower().Contains(filter)
                    || c.Action.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<MenuItem> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new MenuItemSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                ShortName = c.ShortName,
                Icon = c.Icon,
                MenuId = c.MenuId,
                MenuName = c.Menu?.Name,
                Controller = c.Controller,
                ControllerAction = c.Action,
                IsMenuShow = c.IsMenuShow,
                IsActive = c.IsActive,
            }).ToList();

            return searchDto;
        }
    }
}
