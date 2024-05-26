using app.EntityModel.AppModels.SalesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class SalesTermsAndConditionConfig : IEntityTypeConfiguration<SalesTermsAndCondition>
    {
        public void Configure(EntityTypeBuilder<SalesTermsAndCondition> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Key).HasMaxLength(50);
            builder.Property(c => c.Value).HasMaxLength(500);
            builder.ToTable(TableNameEnum.SalesTermsAndCondition.ToString());
        }
    }
}