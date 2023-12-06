using app.Services.CompanyServices;
using app.Services.DropDownServices;
using app.Services.MainMenuServices;
using app.Services.MenuItemServices;
using app.Services.RolesServices;
using app.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using app.Services.UserPermissionsServices;
using app.Services.DepartmentServices;
<<<<<<< HEAD
using app.Services.GradeServices;
=======
using app.Services.DesignationServices;
>>>>>>> 1a047ec59cb181f128dca383423de02d92ca7f11

namespace app.Services
{
    public static class IocContainer
    {
        public static IServiceCollection AddServiceModel(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMainMenuService, MainMenuService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<IUserPermissionService, UserPermissionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDropDownService, DropDownService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
<<<<<<< HEAD
            services.AddTransient<IGradeService, GradeService>();
=======
            services.AddTransient<IDesignationService, DesignationService>();

>>>>>>> 1a047ec59cb181f128dca383423de02d92ca7f11
            return services;
        }
    }
}
