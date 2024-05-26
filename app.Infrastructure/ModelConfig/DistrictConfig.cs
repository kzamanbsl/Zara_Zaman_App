using app.EntityModel.AppModels.AddressModels;
using app.EntityModel.CoreModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class DistrictConfig : IEntityTypeConfiguration<District>
    {

        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.BnName).HasMaxLength(250);

            builder.ToTable(TableNameEnum.District.ToString());
        }
    }
}
