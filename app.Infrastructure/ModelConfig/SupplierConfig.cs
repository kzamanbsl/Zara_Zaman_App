using app.EntityModel.AppModels.SupplierManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250);
            builder.Property(c => c.Phone).HasMaxLength(11);
            builder.Property(c => c.Email).HasMaxLength(250);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Address).HasMaxLength(500);
            builder.ToTable(TableNameEnum.Supplier.ToString());
        }
    }
}