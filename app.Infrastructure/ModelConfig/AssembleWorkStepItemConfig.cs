using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class AssembleWorkStepItemConfig : IEntityTypeConfiguration<AssembleWorkStepItem>
    {

        public void Configure(EntityTypeBuilder<AssembleWorkStepItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(500);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWorkStepItem.ToString());
        }
    }
}