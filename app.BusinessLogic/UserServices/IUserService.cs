using app.Infrastructure.Auth;

namespace app.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> AddUser(UserViewModel vm);
        Task<bool> UpdateUser(UserViewModel vm);
      
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<UserViewModel> GetUserById(string userId);
        Task<UserViewModel> GetAllRecord();
        Task<bool> SoftDelete(string userId);
       
    
    }
}
