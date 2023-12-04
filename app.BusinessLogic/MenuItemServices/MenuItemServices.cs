using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Repository;

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

        public async Task<bool> AddRecord(MenuItemViewModel model)
        {
            var getItem = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == model.Name && f.Action == model.Action && f.Controller == model.Controller);
            if (getItem == null)
            {
                MenuItem item = new MenuItem();
                item.Name = model.Name;
                item.ShortName = model.ShortName;
                item.Icon = model.Icon;
                item.MenuId = model.MenuId;
                item.Action = model.Action;
                item.Controller = model.Controller;
                item.OrderNo = model.OrderNo;
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
                                                   }).OrderByDescending(x => x.OrderNo).AsEnumerable());
            return model;
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
            return model;
        }

        public async Task<bool> UpdateRecord(MenuItemViewModel model)
        {
            var getItem = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name == model.Name && f.Action == model.Action && f.Controller == model.Controller && f.Id != model.Id);
            if (getItem == null)
            {
                MenuItem item = await _iEntityRepository.GetByIdAsync(model.Id);
                item.Name = model.Name;
                item.ShortName = model.ShortName;
                item.Icon = model.Icon;
                item.MenuId = model.MenuId;
                item.Action = model.Action;
                item.Controller = model.Controller;
                item.OrderNo = model.OrderNo;
                item.IsActive = model.IsActive;
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
    }
}
