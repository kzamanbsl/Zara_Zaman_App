using app.EntityModel.AppModels.AttendanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class AttendanceLogConfig : IEntityTypeConfiguration<AttendanceLog>
    {

        public void Configure(EntityTypeBuilder<AttendanceLog> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);
            

            builder.ToTable(TableNameEnum.AttendanceLog.ToString());
        }
    }
}