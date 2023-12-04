using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class TestItemConfig : IEntityTypeConfiguration<TestItem>
    {

        public void Configure(EntityTypeBuilder<TestItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);

            builder.ToTable(TableNameEnum.TestItem.ToString());
        }
    }
}