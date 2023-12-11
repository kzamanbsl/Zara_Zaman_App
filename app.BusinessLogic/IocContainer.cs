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
using app.Services.GradeServices;
using app.Services.DesignationServices;
using app.Services.EmployeeCategoryServices;
using app.Services.ServiceTypeServices;
using app.Services.ShiftServices;
using app.Services.EmployeeServiceTypeServices;
using app.Services.OfficeTypeServices;
using app.Services.DropDownItemServices;
using app.Services.LeaveBalanceServices;

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
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IDesignationService, DesignationService>();
            services.AddTransient<IEmployeeCategoryService, EmployeeCategoryService>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();
            services.AddTransient<IShiftService, ShiftService>();
            services.AddTransient<IEmployeeServiceTypeService,EmployeeServiceTypeService>();
            services.AddTransient<IOfficeTypeService, OfficeTypeService>();
            services.AddTransient<IDropDownItemService, DropDownItemService>();
            services.AddTransient<ILeaveBalanceService, LeaveBalanceService>();


            return services;
        }
    }
}
