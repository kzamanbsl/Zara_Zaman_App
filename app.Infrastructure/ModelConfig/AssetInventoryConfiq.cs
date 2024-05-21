using app.EntityModel.AppModels.AssetManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class AssetAssetInventoryConfig : IEntityTypeConfiguration<AssetInventory>
    {
        public void Configure(EntityTypeBuilder<AssetInventory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(500);
            builder.ToTable(TableNameEnum.AssetInventory.ToString());
        }
    }
}
