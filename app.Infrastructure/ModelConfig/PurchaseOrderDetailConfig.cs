using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.Purchase;

namespace app.Infrastructure.ModelConfig
{

    public class PurchaseOrderDetailConfig : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Remarks).HasMaxLength(250);

            builder.ToTable(TableNameEnum.PurchaseOrderDetail.ToString());
        }
    }
}
