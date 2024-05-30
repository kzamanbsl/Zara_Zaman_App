﻿using app.EntityModel.AppModels.AttendanceModels;
using app.EntityModel.AppModels.BankModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.ModelConfig
{
    internal class BankBranchConfig : IEntityTypeConfiguration<BankBranch>
    {

        public void Configure(EntityTypeBuilder<BankBranch> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable(TableNameEnum.BankBranch.ToString());
        }
    }
}