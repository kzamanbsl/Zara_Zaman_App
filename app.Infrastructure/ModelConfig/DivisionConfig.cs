using app.EntityModel.AppModels;
using app.EntityModel.CoreModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class DivisionConfig : IEntityTypeConfiguration<Division>
    {

        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.BnName).HasMaxLength(250);

            builder.ToTable(TableNameEnum.Division.ToString());
        }
    }
}
