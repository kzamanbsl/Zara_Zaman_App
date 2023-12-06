using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class ServiceTypeConfig : IEntityTypeConfiguration<ServiceType>
    {

        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.ToTable(TableNameEnum.ServiceType.ToString());
        }
    }
}
