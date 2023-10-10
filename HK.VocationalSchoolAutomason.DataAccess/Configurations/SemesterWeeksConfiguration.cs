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
    public class SemesterWeeksConfiguration : IEntityTypeConfiguration<SemesterWeek>
    {
        public void Configure(EntityTypeBuilder<SemesterWeek> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.StartTime).HasColumnType("date");
            builder.Property(x => x.EndTime).HasColumnType("date");

            builder.HasOne(x => x.Semester).WithMany(x => x.SemesterWeeks).HasForeignKey(x => x.SemesterId);
            builder.HasOne(x => x.Weeks).WithMany(x => x.SemesterWeeks).HasForeignKey(x => x.WeeksId);
            builder.HasIndex(x => new { x.WeeksId, x.SemesterId }).IsUnique();
        }
    }
}
