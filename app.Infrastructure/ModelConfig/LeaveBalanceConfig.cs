using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class LeaveBalanceConfig : IEntityTypeConfiguration<LeaveBalance>
    {

        public void Configure(EntityTypeBuilder<LeaveBalance> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.ToTable(TableNameEnum.LeaveBalance.ToString());
        }
    }
}