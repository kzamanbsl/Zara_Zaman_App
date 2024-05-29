using app.EntityModel.AppModels.AssetModels;
using app.Services.AssetAllocationDetailServices;
using app.Services.AssetAllocationServices;
using app.Services.AssetCategoryServices;
using app.Services.AssetInventoryServices;
using app.Services.AssetItemServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Services.AssetPurchaseOrderServices;
using app.Services.AssetTransferDetailServices;
using app.Services.AssetTransferServices;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.ATMAssemble.AssembleWorkEmployeeServices;
using app.Services.ATMAssemble.AssembleWorkServices;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Services.ATMAssemble.AssembleWorkStepServices;
using app.Services.AttendanceLogServices;
using app.Services.AttendanceServices;
using app.Services.BankBranchServices;
using app.Services.BankServices;
using app.Services.CompanyServices;
using app.Services.CustomerServices;
using app.Services.DepartmentServices;
using app.Services.DesignationServices;
using app.Services.DropdownItemServices;
using app.Services.DropdownServices;
using app.Services.EmployeeCategoryServices;
using app.Services.EmployeeGradeServices;
using app.Services.EmployeeServices;
using app.Services.EmployeeServiceTypeServices;
using app.Services.IAssetnventoryServices;
using app.Services.InventoryServices;
using app.Services.JobStatusServices;
using app.Services.LeaveApplicationServices;
using app.Services.LeaveBalanceServices;
using app.Services.LeaveCategoryServices;
using app.Services.MainMenuServices;
using app.Services.MenuItemServices;
using app.Services.OfficeTypeServices;
using app.Services.ProductCategoryServices;
using app.Services.ProductServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
using app.Services.RolesServices;
using app.Services.SaleCenterServices;
using app.Services.SalesOrderDetailServices;
using app.Services.SalesOrderServices;
using app.Services.SalesProductDetailServices;
using app.Services.SalesTermsAndConditonServices;
using app.Services.ServiceCenterServices;
using app.Services.ShiftServices;
using app.Services.StorehouseServices;
using app.Services.SupplierCategoryServices;
using app.Services.SupplierServices;
using app.Services.UnitServices;
using app.Services.UserPermissionsServices;
using app.Services.UserServices;
using app.Utility.UtilityServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<IEmployeeServiceTypeService, EmployeeServiceTypeService>();
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
            services.AddTransient<ISalesOrderDetailService, SalesOrderDetailService>();
            services.AddTransient<IAssetAllocationService, AssetAllocationService>();
            services.AddTransient<ISalesProductDetailService, SalesProductDetailService>();
            services.AddTransient<IAssetAllocationService, AssetAllocationService>();
            services.AddTransient<IAssetAllocationDetailService, AssetAllocationDetailService>();
            services.AddTransient<IAssetAllocationService, AssetAllocationService>();
            services.AddTransient<IAssetAllocationDetailService, AssetAllocationDetailService>();
            services.AddTransient<ISupplierCategoryService, SupplierCategoryService>();
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IBankBranchService, BankBranchService>();
            services.AddTransient<IAssetTransferService, AssetTransferService>();
            services.AddTransient<IAssetTransferDetailService, AssetTransferDetailService>();


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
