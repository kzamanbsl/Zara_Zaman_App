using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.CoreModel;
using app.Infrastructure.ModelConfig.ATMAssemble;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.ModelConfig
{
    public class BaseModelConfig
    {
        public void ModelBuilderConfig(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            new MainMenuConfig()?.Configure(builder.Entity<MainMenu>());
            new MenuItemConfig()?.Configure(builder.Entity<MenuItem>());
            new UserPermissionsConfig()?.Configure(builder.Entity<UserPermissions>());
            new CompanyConfig()?.Configure(builder.Entity<Company>());
            new CountryConfig()?.Configure(builder.Entity<Country>());
            new DivisionConfig()?.Configure(builder.Entity<Division>());
            new DistrictConfig()?.Configure(builder.Entity<District>());
            new UpazilaConfig()?.Configure(builder.Entity<Upazila>());

            new DepartmentConfig()?.Configure(builder.Entity<Department>());
            new EmployeeGradeConfig()?.Configure(builder.Entity<EmployeeGrade>());
            new DesignationConfig()?.Configure(builder.Entity<Designation>());
            new EmployeeCategoryConfig()?.Configure(builder.Entity<EmployeeCategory>());
            new ShiftConfig()?.Configure(builder.Entity<Shift>());
            new OfficeTypeConfig()?.Configure(builder.Entity<OfficeType>());
            new DropdownItemConfig()?.Configure(builder.Entity<DropdownItem>());
            new EmployeeServiceTypeConfig()?.Configure(builder.Entity<EmployeeServiceType>());
            new LeaveBalanceConfig()?.Configure(builder.Entity<LeaveBalance>());
            new LeaveCategoryConfig()?.Configure(builder.Entity<LeaveCategory>());
            new LeaveApplicationConfig()?.Configure(builder.Entity<LeaveApplication>());
            new EmployeeConfig()?.Configure(builder.Entity<Employee>());
            new AttendanceConfig()?.Configure(builder.Entity<Attendance>());
            new AttendanceLogConfig()?.Configure(builder.Entity<AttendanceLog>());
            new JobStatusConfig()?.Configure(builder.Entity<JobStatus>());
            new UnitConfig()?.Configure(builder.Entity<Unit>());
            new ProductCategoryConfig()?.Configure(builder.Entity<ProductCategory>());
            new ProductConfig()?.Configure(builder.Entity<Product>());
            new CustomerConfig()?.Configure(builder.Entity<Customer>());
            new SupplierConfig()?.Configure(builder.Entity<Supplier>());
            new PurchaseOrderConfig()?.Configure(builder.Entity<PurchaseOrder>());
            new PurchaseOrderDetailConfig()?.Configure(builder.Entity<PurchaseOrderDetail>());
            new InventoryConfig()?.Configure(builder.Entity<Inventory>());
            new AssetInventoryConfig()?.Configure(builder.Entity<AssetInventory>());
            new SalesTermsAndConditionConfig()?.Configure(builder.Entity<SalesTermsAndCondition>());
            new SalesOrderConfig()?.Configure(builder.Entity<SalesOrder>());
            new SalesOrderDetailsConfig()?.Configure(builder.Entity<SalesOrderDetails>());
            new AssetAllocationConfig()?.Configure(builder.Entity<AssetAllocation>());
            new AssetAllocationDetailConfig()?.Configure(builder.Entity<AssetAllocationDetail>());
            new SupplierCategoryConfig()?.Configure(builder.Entity<SupplierCategory>());


            #region   AssembleWorkCategory,

            new AssembleWorkCategoryConfig()?.Configure(builder.Entity<AssembleWorkCategory>());
            new AssembleWorkStepConfig()?.Configure(builder.Entity<AssembleWorkStep>());
            new AssembleWorkStepItemConfig()?.Configure(builder.Entity<AssembleWorkStepItem>());
            new AssembleWorkConfig()?.Configure(builder.Entity<AssembleWork>());
            new AssembleWorkEmployeeConfig()?.Configure(builder.Entity<AssembleWorkEmployee>());
            new AssembleWorkDetailConfig()?.Configure(builder.Entity<AssembleWorkDetail>());

            #endregion

        }
    }
}
