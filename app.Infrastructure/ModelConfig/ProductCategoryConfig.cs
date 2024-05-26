using app.EntityModel.AppModels.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.ProductCategory.ToString());
        }
    }
}