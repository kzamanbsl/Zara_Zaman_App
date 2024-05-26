using app.EntityModel.AppModels.LeaveModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class LeaveApplicationConfig : IEntityTypeConfiguration<LeaveApplication>
    {
        public void Configure(EntityTypeBuilder<LeaveApplication> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StayDuringLeave).HasMaxLength(250);
            builder.Property(c => c.Reason).HasMaxLength(500);
            builder.Property(c => c.Remarks).HasMaxLength(500);

            builder.ToTable(TableNameEnum.LeaveApplication.ToString());
        }
    }
}
