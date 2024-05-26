using app.EntityModel.AppModels;
using app.EntityModel.CoreModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {

        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250);
            builder.Property(c => c.ShortName).HasMaxLength(250);

            builder.ToTable(TableNameEnum.MenuItem.ToString());
        }
    }
}