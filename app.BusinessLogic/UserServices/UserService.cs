using app.Infrastructure;
using Microsoft.EntityFrameworkCore;
using app.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using app.EntityModel.DataTablePaginationModels;

namespace app.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly InventoryDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWorkContext _iWorkContext;
        public UserService(InventoryDbContext dbContext, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, IWorkContext iWorkContext)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddUser(UserViewModel vm)
        {
            var userCheck = _dbContext.Users.FirstOrDefault(f => f.Email == vm.Email);
            var loginUser = await _iWorkContext.GetCurrentUserAsync();
            if (userCheck != null) { return false; }
            ApplicationUser users = new ApplicationUser();
            users.FullName = vm.FullName;
            users.UserName = vm.Email;
            users.UserName = vm.UserName;
            users.PhoneNumber = vm.Mobile;
            users.Email = vm.Email;
            users.Address = vm.Address;
            users.Prefix = vm.Password;

            if (vm.RoleName == "Admin")
            { vm.UserType = 1; }

            if (vm.RoleName == "Customer")
            { vm.UserType = 2; }

            users.UserType = vm.UserType;
            users.CreatedOn = DateTime.Now;
            users.CreatedBy = loginUser.FullName;
            users.IsActive = true;
            var result = await _userManager.CreateAsync(users, vm.Password);

            if (result.Succeeded)
            {
                var role = _roleManager.FindByIdAsync(vm.RoleName).Result;
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(users, role.Name);
                }
            }
            return true;
        }
        public async Task<bool> UpdateUser(UserViewModel vm)
        {
            var userCheck = _dbContext.Users.FirstOrDefault(f => f.Email == vm.Email && f.Id != vm.UserId);
            if (userCheck != null) { return false; }

            ApplicationUser user = _dbContext.Users.FirstOrDefault(f => f.Id == vm.UserId);
            if (user == null) { return false; }

            var currentName = _dbContext.UserRoles.FirstOrDefault(g => g.UserId == vm.UserId);
            var oldRole = _dbContext.Roles.FirstOrDefault(g => g.Id == currentName.RoleId);
            var loginUser = await _iWorkContext.GetCurrentUserAsync();
            var role = _roleManager.FindByIdAsync(vm.RoleId).Result;
            user.FullName = vm.FullName;
            user.UserName = vm.Email;
            user.PhoneNumber = vm.Mobile;
            user.Email = vm.Email;
            user.Address = vm.Address;
            user.IsActive = vm.IsActive;
            if (role.Name == "Admin") { user.UserType = 1; }
            if (role.Name == "Customer") { user.UserType = 2; }
            user.UpdatedOn = DateTime.Now;
            user.UpdatedBy = loginUser.FullName;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (role != null)
                {
                    await _userManager.RemoveFromRoleAsync(user, oldRole.Name);
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                return true;
            }
            return false;
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(d => d.Email == email && d.IsActive == true);
            return result;
        }
        public async Task<UserViewModel> GetUserById(string userId)
        {
            var model = await _dbContext.Users.FirstOrDefaultAsync(d => d.Id == userId);
            UserViewModel users = new UserViewModel();
            users.FullName = model.FullName;
            users.UserName = model.Email;
            users.Mobile = model.PhoneNumber;
            users.Email = model.Email;
            users.UserType = model.UserType;
            users.UserId = model.Id;
            users.Address = model.Address;
            users.IsActive = model.IsActive;
            users.RoleId = _dbContext.UserRoles.FirstOrDefault(g => g.UserId == model.Id)?.RoleId;
            return users;
        }
        public async Task<bool> SoftDelete(string userId)
        {
            var model = await _dbContext.Users.FirstOrDefaultAsync(d => d.Id == userId);
            var user = await _iWorkContext.GetCurrentUserAsync();
            model.IsActive = false;
            model.UpdatedOn = DateTime.Now;
            model.UpdatedBy = user.FullName;
            var result = await _userManager.UpdateAsync(model);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<UserViewModel> GetAllRecord()
        {
            UserViewModel model = new UserViewModel();
            model.DataList = await Task.Run(() => (from t1 in _dbContext.Users
                                                   select new UserViewModel
                                                   {
                                                       UserId = t1.Id,
                                                       FullName = t1.FullName,
                                                       UserName = t1.UserName,
                                                       IsActive = t1.IsActive,
                                                       Email = t1.Email,
                                                       Mobile = t1.PhoneNumber,
                                                   }).OrderByDescending(x => x.UserName).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<UserSearchDto>> SearchAsync(DataTablePagination<UserSearchDto> searchDto)
        {
            var searchResult = _dbContext.Users.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.FullName.ToLower().Contains(filter)
                    || c.UserName.ToLower().Contains(filter)
                    || c.Email.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<ApplicationUser> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new UserSearchDto()
            {
                SerialNo = ++sl,
                UserId = c.Id,
                FullName = c.FullName,
                UserName = c.UserName,
                Email = c.Email,
                IsActive = c.IsActive,
            }).ToList();

            return searchDto;
        }
    }
}
