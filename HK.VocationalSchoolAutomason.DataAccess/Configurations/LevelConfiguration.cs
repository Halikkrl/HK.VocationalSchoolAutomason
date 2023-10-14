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
    public class LevelConfiguration : IEntityTypeConfiguration<Levels>
    {
        public void Configure(EntityTypeBuilder<Levels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LevelName).IsRequired();
            builder.Property(x => x.LevelName).HasMaxLength(10);
            builder.HasIndex(x => x.LevelName).IsUnique();
        }
    }
}
