using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.SalesModels;

namespace app.Infrastructure.ModelConfig
{
    public class SalesOrderConfig : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(500);

            builder.ToTable(TableNameEnum.SalesOrder.ToString());
        }
    }
}
