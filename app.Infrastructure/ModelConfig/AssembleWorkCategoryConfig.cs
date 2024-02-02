using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class AssembleWorkCategoryConfig : IEntityTypeConfiguration<AssembleWorkCategory>
    {

        public void Configure(EntityTypeBuilder<AssembleWorkCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWorkCategory.ToString());
        }
    }
}