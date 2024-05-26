using app.EntityModel.AppModels.CustomerModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Email).HasMaxLength(250);
            builder.Property(c => c.Phone).HasMaxLength(11);
            builder.Property(c => c.Address).HasMaxLength(500);
            builder.ToTable(TableNameEnum.Customer.ToString());
        }
    }
}
