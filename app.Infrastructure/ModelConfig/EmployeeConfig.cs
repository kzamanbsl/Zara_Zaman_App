using app.EntityModel.AppModels;
using app.Infrastructure.ModelConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(250);
            builder.Property(e => e.ShortName).HasMaxLength(100);
            builder.Property(e => e.FatherName).HasMaxLength(200);
            builder.Property(e => e.MotherName).HasMaxLength(200);
            builder.Property(e => e.MobileNo).HasMaxLength(11);
            builder.ToTable(TableNameEnum.Employee.ToString());
        }
    }
}
