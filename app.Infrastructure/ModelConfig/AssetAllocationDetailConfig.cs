using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.AssetManage;

namespace app.Infrastructure.ModelConfig
{

    public class AssetAllocationDetailConfig : IEntityTypeConfiguration<AssetAllocationDetail>
    {
        public void Configure(EntityTypeBuilder<AssetAllocationDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Tags).HasMaxLength(2000);

            builder.ToTable(TableNameEnum.AssetAllocationDetail.ToString());
        }
    }
}
