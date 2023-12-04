namespace app.Services.RolesServices
{
    public interface IRoleService
    {
        Task<RoleViewModel> GetByIdAsync(string id);
        Task<bool> AddAsync(RoleViewModel model);
        Task<bool> UpdateAsync(RoleViewModel model);
        int TotalCount();
        Task<bool> DeleteByIdAsync(string id);
        List<RoleViewModel> GetAllAsync();
    }
}
