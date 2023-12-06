﻿using app.Infrastructure;
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

        public async Task<bool> AddAsync(RoleViewModel model)
        {
            var exited = await _roleManager.FindByNameAsync(model.Name.Trim());
            if (exited == null)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {

                    return true;
                }
            }
            return false;

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

        public int TotalCount()
        {
            return _roleManager.Roles.Count();
        }

        public async Task<bool> UpdateAsync(RoleViewModel model)
        {
            var exited = _roleManager.FindByNameAsync(model.Name).Result;
            var exitedId = _roleManager.FindByIdAsync(model.Id).Result;
            if (exited == null)
            {
                var role = _roleManager.FindByIdAsync(model.Id).Result;
                role.Id = model.Id;
                role.Name = model.Name;
                var result = await _roleManager.UpdateAsync(role);
                return result.Succeeded;

            }

            return false;
        }


    }
}
