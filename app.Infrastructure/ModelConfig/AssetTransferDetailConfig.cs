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
    public class AssetTransferDetailConfig : IEntityTypeConfiguration<AssetTransferDetail>
    {
        public void Configure(EntityTypeBuilder<AssetTransferDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);


            builder.ToTable(TableNameEnum.AssetTransferDetail.ToString());
        }
    }
}
