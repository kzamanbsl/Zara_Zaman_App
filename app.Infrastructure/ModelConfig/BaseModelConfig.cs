using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
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

        }
    }
}
