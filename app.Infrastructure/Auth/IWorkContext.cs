namespace app.Infrastructure.Auth
{
    public interface IWorkContext
    {
        Task<ApplicationUser> GetCurrentAdminUserAsync();
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<bool> IsUserSignedIn();
    }
}
