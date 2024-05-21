using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using app.EntityModel.AppModels.Sales;

namespace app.Infrastructure.ModelConfig
{
    public class SalesProductDetailConfig : IEntityTypeConfiguration<SalesProductDetail>
    {

        public void Configure(EntityTypeBuilder<SalesProductDetail> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable(TableNameEnum.SalesProductDetail.ToString());
        }
    }
}
