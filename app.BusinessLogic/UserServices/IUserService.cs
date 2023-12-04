using app.Infrastructure.Auth;

namespace app.Services.UserServices
{
    public interface IUserService
    {
        Task<UserViewModel> GetAllRecord();
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<UserViewModel> GetUserById(string userId);
        Task<bool> SoftDelete(string userId);
        Task<int> AddUser(UserViewModel model);
        Task<int> UpdateUser(UserViewModel model);
    
    }
}
