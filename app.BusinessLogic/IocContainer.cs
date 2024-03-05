using app.Services.CompanyServices;
using app.Services.DropdownServices;
using app.Services.MainMenuServices;
using app.Services.MenuItemServices;
using app.Services.RolesServices;
using app.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using app.Services.UserPermissionsServices;
using app.Services.DepartmentServices;
using app.Services.DesignationServices;
using app.Services.EmployeeCategoryServices;
using app.Services.ShiftServices;
using app.Services.EmployeeServiceTypeServices;
using app.Services.OfficeTypeServices;
using app.Services.DropdownItemServices;
using app.Services.LeaveCategoryServices;
using app.Utility.UtilityServices;
using app.Services.LeaveBalanceServices;
using app.Services.LeaveApplicationServices;
using app.Services.EmployeeServices;
using app.Services.AttendanceServices;
using app.Services.AttendanceLogServices;
using app.Services.EmployeeGradeServices;
using app.Services.JobStatusServices;
using app.Services.UnitServices;
using app.Services.ProductCategoryServices;
using app.Services.SupplierServices;
using app.Services.ProductServices;
using app.Services.CustomerServices;
using app.Services.StorehouseServices;
using app.Services.PurchaseOrderServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.AssetCategoryServices;
using app.Services.AssetItemServices;
using app.Services.ServiceCenterServices;
using app.Services.SaleCenterServices;
using app.Services.ATMAssemble.AssembleWorkStepServices;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Services.ATMAssemble.AssembleWorkServices;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.ATMAssemble.AssembleWorkEmployeeServices;
using app.Services.InventoryServices;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Services.SalesTermsAndConditonServices;
using app.Services.IAssetnventoryServices;
using app.Services.AssetInventoryServices;
using app.Services.SalesOrderServices;
using app.Services.SalesOrderDetailServices;
using app.Services.AssetAllocationServices;
using app.Services.AssetAllocationDetailServices;

namespace app.Services
{
    public static class IocContainer
    {
        public static IServiceCollection AddServiceModel(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IMainMenuService, MainMenuService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<IUserPermissionService, UserPermissionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDropdownService, DropdownService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IEmployeeGradeService, EmployeeGradeService>();
            services.AddTransient<IDesignationService, DesignationService>();
            services.AddTransient<IEmployeeCategoryService, EmployeeCategoryService>();
            services.AddTransient<IShiftService, ShiftService>();
            services.AddTransient<IEmployeeServiceTypeService,EmployeeServiceTypeService>();
            services.AddTransient<IOfficeTypeService, OfficeTypeService>();
            services.AddTransient<IDropdownItemService, DropdownItemService>();
            services.AddTransient<ILeaveBalanceService, LeaveBalanceService>();
            services.AddTransient<ILeaveCategoryService, LeaveCategoryService>();
            services.AddTransient<ILeaveApplicationService, LeaveApplicationService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IAttendanceLogService, AttendanceLogService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IJobStatusService, JobStatusService>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<ISupplierService, SupplierService>(); 
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IStorehouseService, StorehouseService>();
            services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();
            services.AddTransient<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            services.AddTransient<IAssetCategoryService, AssetCategoryService>();
            services.AddTransient<IAssetItemService, AssetItemService>();
            services.AddTransient<IServiceCenterService, ServiceCenterService>();
            services.AddTransient<ISaleCenterService, SaleCenterService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IAssetPurchaseOrderService, AssetPurchaseOrderService>();
            services.AddTransient<IAssetPurchaseOrderDetailService, AssetPurchaseOrderDetailService>();
            services.AddTransient<ISalesTermsAndConditionService, SalesTermsAndConditionService>();
            services.AddTransient<ISalesOrderService, SalesOrderService>();
            services.AddTransient<ISalesOrderDetailService,SalesOrderDetailService>();
            services.AddTransient<IAssetAllocationService, AssetAllocationService>();
            //services.AddTransient<IAssetAllocationDetailService, AssetAllocationDetailService>();

            #region ATM Assemble
            services.AddTransient<IAssetInventoryService, AssetInventoryService>();
            services.AddTransient<IAssembleWorkCategoryService, AssembleWorkCategoryService>();
            services.AddTransient<IAssembleWorkStepService, AssembleWorkStepService>();
            services.AddTransient<IAssembleWorkStepItemService, AssembleWorkStepItemService>();
            services.AddTransient<IAssembleWorkService, AssembleWorkService>();
            services.AddTransient<IAssembleWorkDetailService, AssembleWorkDetailService>();
            services.AddTransient<IAssembleWorkEmployeeService, AssembleWorkEmployeeService>();
            #endregion

            return services;
        }
    }
}
