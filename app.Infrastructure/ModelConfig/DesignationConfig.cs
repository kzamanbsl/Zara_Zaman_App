using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.EntityModel.AppModels.Office;

namespace app.Infrastructure.ModelConfig
{
    public class DesignationConfig : IEntityTypeConfiguration<Designation>
    {

        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.Designation.ToString());
        }
    }
}
