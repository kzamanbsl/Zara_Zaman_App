using app.EntityModel.AppModels.ATMAssembleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
{
    public class AssembleWorkConfig : IEntityTypeConfiguration<AssembleWork>
    {

        public void Configure(EntityTypeBuilder<AssembleWork> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasMany(c=>c.WorkDetails).WithOne(c=>c.AssembleWork).HasForeignKey(c=>c.AssembleWorkId);
            builder.HasMany(c=>c.WorkEmployees).WithOne(c=>c.AssembleWork).HasForeignKey(c=>c.AssembleWorkId);
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.ToTable(TableNameEnum.AssembleWork.ToString());
        }
    }
}