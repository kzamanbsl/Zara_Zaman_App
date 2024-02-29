using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.ModelConfig
{

    public class SalesOrderDetailsConfig : IEntityTypeConfiguration<SalesOrderDetails>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetails> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);

            builder.ToTable(TableNameEnum.SalesOrderDetails.ToString());
        }
    }
}
