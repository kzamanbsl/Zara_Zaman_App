using app.EntityModel.AppModels.ATMAssembleModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig.ATMAssemble
{
    public class AssembleWorkDetailConfig : IEntityTypeConfiguration<AssembleWorkDetail>
    {

        public void Configure(EntityTypeBuilder<AssembleWorkDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.AssembleWork).WithMany(c => c.WorkDetails).HasForeignKey(c => c.AssembleWorkId);
            builder.Property(c => c.Remarks).HasMaxLength(250);

            builder.ToTable(TableNameEnum.AssembleWorkDetail.ToString());
        }
    }
}