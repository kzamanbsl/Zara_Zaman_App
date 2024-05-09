using app.EntityModel.AppModels.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class OfficeTypeConfig : IEntityTypeConfiguration<OfficeType>
    {
        public void Configure(EntityTypeBuilder<OfficeType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.OfficeType.ToString());
        }
    }
}
