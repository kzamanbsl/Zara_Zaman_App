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
    public class DropDownItemConfig : IEntityTypeConfiguration<DropDownItem>
    {
        public void Configure(EntityTypeBuilder<DropDownItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.DropDownItem.ToString());
        }
    }
}
