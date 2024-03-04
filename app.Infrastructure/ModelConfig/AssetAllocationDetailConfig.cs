using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.ModelConfig
{

    public class AssetAllocationDetailConfig : IEntityTypeConfiguration<AssetAllocationDetail>
    {
        public void Configure(EntityTypeBuilder<AssetAllocationDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssetAllocationDetail.ToString());
        }
    }
}
