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
    public class AssetInventoryConfig : IEntityTypeConfiguration<AssetInventory>
    {
        public void Configure(EntityTypeBuilder<AssetInventory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(500);
            builder.ToTable(TableNameEnum.AssetInventory.ToString());
        }
    }
}
