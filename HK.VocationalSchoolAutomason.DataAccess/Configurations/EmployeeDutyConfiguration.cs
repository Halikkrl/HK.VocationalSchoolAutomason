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
    public class EmployeeDutyConfiguration : IEntityTypeConfiguration<EmployeeDuty>
    {
        public void Configure(EntityTypeBuilder<EmployeeDuty> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Employee).WithMany(x => x.EmployeeDuties).HasForeignKey(e => e.EmployeeId);
            builder.HasOne(x => x.Duty).WithMany(x => x.EmployeeDuties).HasForeignKey(x => x.DutyId);

            builder.HasIndex(x => x.EmployeeId).IsUnique();
            
        }
    }
}
