using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.ISOCode).HasMaxLength(30);
            builder.Property(c => c.Code).HasMaxLength(4);

            builder.ToTable(TableNameEnum.Country.ToString());
        }
    }
}
