using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssembleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
{
    public class AssembleWorkStepConfig : IEntityTypeConfiguration<AssembleWorkStep>
    {

        public void Configure(EntityTypeBuilder<AssembleWorkStep> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWorkStep.ToString());
        }
    }
}