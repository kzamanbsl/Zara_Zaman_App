using app.EntityModel.AppModels.BankManage;
using app.EntityModel.AppModels.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Infrastructure.ModelConfig
{
    public class BankConfig : IEntityTypeConfiguration<Bank>
    {

        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.Bank.ToString());
        }
    }
}