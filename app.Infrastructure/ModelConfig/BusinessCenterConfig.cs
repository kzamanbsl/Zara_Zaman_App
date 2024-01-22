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
    public class BusinessCenterConfig : IEntityTypeConfiguration<BusinessCenter>
    {
        public void Configure(EntityTypeBuilder<BusinessCenter> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.Property(c => c.Location).HasMaxLength(250);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.BusinessCenter.ToString());
        }
    }
}
