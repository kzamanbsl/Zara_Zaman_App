using app.Infrastructure;
using Microsoft.EntityFrameworkCore;
using app.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;

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

        public async Task<int> AddUser(UserViewModel model)
        {
            var userCheck = _dbContext.Users.FirstOrDefault(f => f.Email == model.Email);
            var loginUser = await _iWorkContext.GetCurrentUserAsync();
            if (userCheck != null) { return 1; }
            ApplicationUser users = new ApplicationUser();
            users.FullName = model.FullName;
            users.UserName = model.Email;
            users.PhoneNumber = model.Mobile;
            users.Email = model.Email;
            users.Address = model.Address;
            users.Prefix = model.Password;

            if (model.RoleName == "Admin")
            { model.UserType = 1; }

            if (model.RoleName == "Customer")
            { model.UserType = 2; }

            users.UserType = model.UserType;
            users.CreatedOn = DateTime.Now;
            users.CreatedBy = loginUser.FullName;
            users.IsActive = true;
            var result = await _userManager.CreateAsync(users, model.Password);

            if (result.Succeeded)
            {
                var role = _roleManager.FindByIdAsync(model.RoleName).Result;
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(users, role.Name);
                }
            }
            return 2;
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

        public async Task<int> UpdateUser(UserViewModel model)
        {
            var userCheck = _dbContext.Users.FirstOrDefault(f => f.Email == model.Email && f.Id != model.UserId);
            if (userCheck != null) { return 1; }

            ApplicationUser user = _dbContext.Users.FirstOrDefault(f => f.Id == model.UserId);
            if (user == null) { return 1; }

            var currentName = _dbContext.UserRoles.FirstOrDefault(g => g.UserId == model.UserId);
            var oldRole = _dbContext.Roles.FirstOrDefault(g => g.Id == currentName.RoleId);
            var loginUser = await _iWorkContext.GetCurrentUserAsync();
            var role = _roleManager.FindByIdAsync(model.RoleId).Result;
            user.FullName = model.FullName;
            user.UserName = model.Email;
            user.PhoneNumber = model.Mobile;
            user.Email = model.Email;
            user.Address = model.Address;
            user.IsActive = model.IsActive;
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
                return 2;
            }
            return 0;
        }
    }
}
