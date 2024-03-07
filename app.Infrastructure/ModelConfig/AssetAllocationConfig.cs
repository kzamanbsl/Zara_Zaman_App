using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.ModelConfig
{
    public class AssetAllocationConfig : IEntityTypeConfiguration<AssetAllocation>
    {
        public void Configure(EntityTypeBuilder<AssetAllocation> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c => c.Tags).HasMaxLength(2000);

            builder.ToTable(TableNameEnum.AssetAllocation.ToString());
        }
    }
}
