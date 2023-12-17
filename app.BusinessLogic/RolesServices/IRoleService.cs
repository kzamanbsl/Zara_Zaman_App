namespace app.Services.RolesServices
{
    public interface IRoleService
    {
      
        Task<bool> AddAsync(RoleViewModel vm);
        Task<bool> UpdateAsync(RoleViewModel vm);
        Task<RoleViewModel> GetByIdAsync(string id);
        List<RoleViewModel> GetAllAsync();
        int TotalCount();
        Task<bool> DeleteByIdAsync(string id);
       
    }
}
