using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class LeaveApplicationConfig : IEntityTypeConfiguration<LeaveApplication>
    {
        public void Configure(EntityTypeBuilder<LeaveApplication> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StayDuringLeave).HasMaxLength(200);
            builder.Property(c => c.Reason).HasMaxLength(500);
            builder.Property(c => c.Remarks).HasMaxLength(500);

            builder.ToTable(TableNameEnum.LeaveApplication.ToString());
        }
    }
}
