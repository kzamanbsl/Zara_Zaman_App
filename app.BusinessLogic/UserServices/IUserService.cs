using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure.Auth;
using app.Services.ProductServices;

namespace app.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> AddUser(UserViewModel vm);
        Task<bool> UpdateUser(UserViewModel vm);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<UserViewModel> GetUserById(string userId);
        Task<bool> SoftDelete(string userId);
        Task<UserViewModel> GetAllRecord();
        Task<DataTablePagination<UserSearchDto>> SearchAsync(DataTablePagination<UserSearchDto> searchDto);


    }
}
