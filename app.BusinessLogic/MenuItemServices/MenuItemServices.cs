using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Repository;
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
                item.IsActive = vm.IsActive;
                item.IsMenuShow = vm.IsMenuShow;
                var result = await _iEntityRepository.UpdateAsync(item);
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

    }
}
