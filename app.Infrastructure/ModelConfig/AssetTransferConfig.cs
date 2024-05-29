using app.EntityModel.AppModels.AssetModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class AssetTransferConfig : IEntityTypeConfiguration<AssetTransfer>
    {
        public void Configure(EntityTypeBuilder<AssetTransfer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(500);


            builder.ToTable(TableNameEnum.AssetTransfer.ToString());
        }
    }
}
