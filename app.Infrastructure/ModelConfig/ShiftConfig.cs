using app.EntityModel.AppModels;
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
            //builder.Property(c => c.StartAt).HasMaxLength(20);
            //builder.Property(c => c.EndAt).HasMaxLength(20);

            builder.ToTable(TableNameEnum.Shift.ToString());
        }
    }
}