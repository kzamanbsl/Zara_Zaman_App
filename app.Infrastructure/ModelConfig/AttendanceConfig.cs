using app.EntityModel.AppModels.Attendance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {

        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);
            

            builder.ToTable(TableNameEnum.Attendance.ToString());
        }
    }
}