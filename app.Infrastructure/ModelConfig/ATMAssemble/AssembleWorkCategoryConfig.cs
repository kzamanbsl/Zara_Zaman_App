using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssembleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
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