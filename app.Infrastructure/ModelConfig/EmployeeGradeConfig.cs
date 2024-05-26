using app.EntityModel.AppModels.EmployeeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class EmployeeGradeConfig : IEntityTypeConfiguration<EmployeeGrade>
    {

        public void Configure(EntityTypeBuilder<EmployeeGrade> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.PayScale).HasMaxLength(250);

            builder.ToTable(TableNameEnum.EmployeeGrade.ToString());
        }
    }
}