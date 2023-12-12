using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class UpazilaConfig : IEntityTypeConfiguration<Upazila>
    {

        public void Configure(EntityTypeBuilder<Upazila> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.BnName).HasMaxLength(250);

            builder.ToTable(TableNameEnum.Upazila.ToString());
        }
    }
}
