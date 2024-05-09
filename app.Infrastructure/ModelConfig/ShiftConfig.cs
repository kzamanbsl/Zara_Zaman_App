using app.EntityModel.AppModels.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {

        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.Shift.ToString());
        }
    }
}