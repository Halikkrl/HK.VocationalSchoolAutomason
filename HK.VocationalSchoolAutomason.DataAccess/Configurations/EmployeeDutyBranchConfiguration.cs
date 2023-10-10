using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class EmployeeDutyBranchConfiguration : IEntityTypeConfiguration<EmployeeDutyBranch>
    {
        public void Configure(EntityTypeBuilder<EmployeeDutyBranch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.EmployeeDuty).WithMany(x => x.EmployeeDutyBranches).HasForeignKey(x => x.EmployeeDutyId);
            builder.HasOne(x => x.Branch).WithMany(x => x.EmployeeDutyBranches).HasForeignKey(x => x.BranchId);

            builder.HasIndex(x => x.EmployeeDutyId).IsUnique();
        }
    }
}
