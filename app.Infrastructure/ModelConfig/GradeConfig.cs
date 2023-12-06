using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.PayScale).HasMaxLength(250);

            builder.ToTable(TableNameEnum.Grade.ToString());
        }
    }
}