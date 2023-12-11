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

            new DepartmentConfig()?.Configure(builder.Entity<Department>());
            new GradeConfig()?.Configure(builder.Entity<Grade>());
            new DesignationConfig()?.Configure(builder.Entity<Designation>());
            new EmployeeCategoryConfig()?.Configure(builder.Entity<EmployeeCategory>());
            new ServiceTypeConfig()?.Configure(builder.Entity<ServiceType>());
            new ShiftConfig()?.Configure(builder.Entity<Shift>());
            new OfficeTypeConfig()?.Configure(builder.Entity<OfficeType>());
            new DropDownItemConfig()?.Configure(builder.Entity<DropDownItem>());
            new EmployeeServiceTypeConfig()?.Configure(builder.Entity<EmployeeServiceType>());
            new LeaveCategoryConfig()?.Configure(builder.Entity<LeaveCategory>());


        }
    }
}
