using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class SupplierCategoryConfig : IEntityTypeConfiguration<SupplierCategory>
    {

        public void Configure(EntityTypeBuilder<SupplierCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.SupplierCategory.ToString());
        }
    }
}