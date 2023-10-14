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
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.SemesterName).IsRequired();
            builder.HasIndex(x => x.SemesterName).IsUnique();
            builder.Property(x => x.SemesterName).HasMaxLength(128);
        }
    }
}
