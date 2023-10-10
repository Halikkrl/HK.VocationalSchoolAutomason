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
    public class WeeksConfiguration : IEntityTypeConfiguration<Weeks>
    {
        public void Configure(EntityTypeBuilder<Weeks> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
