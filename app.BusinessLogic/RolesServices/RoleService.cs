using app.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace app.Services.RolesServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly InventoryDbContext _dbContext;
        public RoleService(RoleManager<IdentityRole> roleManager, InventoryDbContext dbContext)
        {
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(RoleViewModel vm)
        {
            var exited = await _roleManager.FindByNameAsync(vm.Name.Trim());
            if (exited == null)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = vm.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {

                    return true;
                }
            }
            return false;

        }
        public async Task<bool> UpdateAsync(RoleViewModel vm)
        {
            var exited = _roleManager.FindByNameAsync(vm.Name).Result;
            if (exited == null)
            {
                var role = _roleManager.FindByIdAsync(vm.Id).Result;
                role.Id = vm.Id;
                role.Name = vm.Name;
                var result = await _roleManager.UpdateAsync(role);
                return result.Succeeded;

            }

            return false;
        }
        public async Task<RoleViewModel> GetByIdAsync(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
            RoleViewModel role = new RoleViewModel()
            {
                Id = result.Id,
                Name = result.Name
            };
            return role;
        }
        public List<RoleViewModel> GetAllAsync()
        {
            List<RoleViewModel> rolesList = new List<RoleViewModel>();
            var roles = _roleManager.Roles.ToList();
            foreach (var item in roles)
            {

                RoleViewModel role = new RoleViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                rolesList.Add(role);
            }
            return rolesList.OrderBy(r => r.Name).ToList();
        }
        public int TotalCount()
        {
            return _roleManager.Roles.Count();
        }
        public async Task<bool> DeleteByIdAsync(string name)
        {
            var exited = await _roleManager.FindByNameAsync(name);
            if (exited != null)
            {
                await _roleManager.DeleteAsync(exited);
                return true;
            }
            return false;

        }

    }
}
