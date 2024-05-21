using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.AssetManage;

namespace app.Infrastructure.ModelConfig
{
    public class AssetAllocationConfig : IEntityTypeConfiguration<AssetAllocation>
    {
        public void Configure(EntityTypeBuilder<AssetAllocation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssetAllocation.ToString());
        }
    }
}
