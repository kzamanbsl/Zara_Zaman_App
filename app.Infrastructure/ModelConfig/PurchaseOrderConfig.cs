using app.EntityModel.AppModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class PurchaseOrderConfig : IEntityTypeConfiguration<PurchaseOrderList>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderList> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(500);

            builder.ToTable(TableNameEnum.PurchaseOrder.ToString());
        }
    }
}
