using app.EntityModel.AppModels.EmployeeManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class EmployeeServiceTypeConfig : IEntityTypeConfiguration<EmployeeServiceType>
    {

        public void Configure(EntityTypeBuilder<EmployeeServiceType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200);

            builder.ToTable(TableNameEnum.EmployeeServiceType.ToString());
        }
    }
}