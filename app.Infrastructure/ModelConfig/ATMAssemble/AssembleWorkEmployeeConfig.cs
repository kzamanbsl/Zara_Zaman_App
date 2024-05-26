using app.EntityModel.AppModels.ATMAssembleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
{
    public class AssembleWorkEmployeeConfig : IEntityTypeConfiguration<AssembleWorkEmployee>
    {

        public void Configure(EntityTypeBuilder<AssembleWorkEmployee> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.AssembleWork).WithMany(c => c.WorkEmployees).HasForeignKey(c => c.AssembleWorkId);
            //builder.Property(c => c.Description).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWorkEmployee.ToString());
        }
    }
}