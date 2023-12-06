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
    public class EmployeeCategoryConfig : IEntityTypeConfiguration<EmployeeCategory>
    {

        public void Configure(EntityTypeBuilder<EmployeeCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.ToTable(TableNameEnum.EmployeeCategory.ToString());
        }
    }
}
