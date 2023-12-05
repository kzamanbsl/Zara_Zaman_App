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

        }
    }
}
