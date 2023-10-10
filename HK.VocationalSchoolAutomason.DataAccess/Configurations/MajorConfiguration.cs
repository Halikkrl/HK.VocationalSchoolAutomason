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
    public class MajorConfiguration : IEntityTypeConfiguration<Majors>
    {

        public void Configure(EntityTypeBuilder<Majors> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x =>x.MajorName).IsRequired();
            builder.Property(x =>x.MajorName).HasMaxLength(100);
            builder.HasIndex(x => x.MajorName).IsUnique();
        }
    }
}
