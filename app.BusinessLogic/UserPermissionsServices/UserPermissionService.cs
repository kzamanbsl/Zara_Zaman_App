using System.Text.RegularExpressions;
using app.EntityModel.CoreModel;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.MenuItemServices;
using Microsoft.EntityFrameworkCore;

namespace app.Services.UserPermissionsServices
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IEntityRepository<UserPermissions> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public UserPermissionService(IEntityRepository<UserPermissions> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(long id, string userId)
        {
            UserPermissions userPermission = new UserPermissions();
            var result = await _dbContext.UserPermissions.FirstOrDefaultAsync(d => d.MenuItemId == id && d.UserId == userId);
            if (result == null)
            {
                userPermission.UserId = userId;
                userPermission.MenuItemId = id;
                var res = await _iEntityRepository.AddAsync(userPermission);
            }
            else
            {
                if (result.IsActive == true)
                {
                    result.IsActive = false;
                }
                else
                {
                    result.IsActive = true;
                }
                var res = await _iEntityRepository.UpdateAsync(result);
            }
            return true;
        }

        public async Task<MenuPermissionViewModel> GetAllMenuItemRecordByUserId(string userId)
        {
            MenuPermissionViewModel viewModel = new MenuPermissionViewModel();
            List<MainMenuVm> models = new List<MainMenuVm>();
            //var user = await workContext.CurrentUserAsync();
            var result = await _dbContext.MainMenu.Where(s => s.IsActive == true).OrderBy(f => f.OrderNo).AsNoTracking().ToListAsync();
            foreach (var item in result)
            {
                string str = item.Name;
                str = Regex.Replace(str, @"\s", "-");
                MainMenuVm vM = new MainMenuVm();
                vM.Name = item.Name;
                vM.Icon = item.Icon;
                vM.ActiveId = str;
                vM.MenuItemVMs = await MapperMission(userId, item.Id);
                models.Add(vM);
            }
            viewModel.MainMenuVm = models;
            return viewModel;
        }

        private async Task<List<MenuItemVm>> MapperMission(string userId, long menuId)
        {
            List<MenuItemVm> menus = new List<MenuItemVm>();
            menus = await Task.Run(() => (from t1 in _dbContext.MenuItem
                                          join t2 in _dbContext.UserPermissions on t1.Id equals t2.MenuItemId
                                          where t2.IsActive == true && t1.MenuId == menuId && t1.IsActive == true && t2.UserId == userId
                                          select new MenuItemVm
                                          {
                                              Id = t1.Id,
                                              Name = t1.Name,
                                              Action = t1.Action,
                                              Controller = t1.Controller,
                                              OrderNo = t1.OrderNo,
                                              Icon = t1.Icon,
                                          }).OrderBy(x => x.OrderNo).AsNoTracking().ToListAsync());
            return menus;
        }

        public async Task<UserPermissionViewModel> GetAllRecordByUserId(string userId)
        {
            UserPermissionViewModel viewModel = new UserPermissionViewModel();
            List<UserPermissionViewModel> models = new List<UserPermissionViewModel>();
            var result = await _dbContext.MainMenu.Where(s => s.IsActive == true).AsNoTracking().ToListAsync();
            foreach (var item in result)
            {
                UserPermissionViewModel model = new UserPermissionViewModel();
                model.MenuName = item.Name;
                models.Add(model);
                var itemList = _dbContext.MenuItem.Where(d => d.MenuId == item.Id && d.IsActive == true).AsNoTracking().ToList();
                List<MenuItemViewModel> menuItemList = new List<MenuItemViewModel>();
                foreach (var menu in itemList)
                {
                    var res = await _dbContext.UserPermissions.FirstOrDefaultAsync(d => d.MenuItemId == menu.Id && d.UserId == userId);
                    MenuItemViewModel vm = new MenuItemViewModel();
                    vm.Id = menu.Id;
                    vm.Name = menu.Name;
                    if (res != null && res.IsActive == true)
                    { vm.IsPermission = true;}

                    else { vm.IsPermission = false; }
                    menuItemList.Add(vm);
                }
                model.MenuItemList = menuItemList;
            }
            viewModel.DataList = models;
            return viewModel;
        }
    }
}
