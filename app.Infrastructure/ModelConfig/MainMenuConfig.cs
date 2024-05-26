using app.EntityModel.AppModels;
using app.EntityModel.CoreModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class MainMenuConfig : IEntityTypeConfiguration<MainMenu>
    {

        public void Configure(EntityTypeBuilder<MainMenu> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.MainMenu.ToString());
        }
    }
}