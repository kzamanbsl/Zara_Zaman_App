using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class UserPermissionsConfig : IEntityTypeConfiguration<UserPermissions>
    {

        public void Configure(EntityTypeBuilder<UserPermissions> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable(TableNameEnum.UserPermissions.ToString());
        }
    }
}