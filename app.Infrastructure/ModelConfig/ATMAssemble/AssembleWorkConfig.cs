using app.EntityModel.AppModels.ATMAssemble;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
{
    public class AssembleWorkConfig : IEntityTypeConfiguration<AssembleWork>
    {

        public void Configure(EntityTypeBuilder<AssembleWork> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWork.ToString());
        }
    }
}