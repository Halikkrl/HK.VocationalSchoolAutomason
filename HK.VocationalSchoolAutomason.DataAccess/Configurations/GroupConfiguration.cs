using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Groups>
    {

        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GroupName).IsRequired();
            builder.Property(x => x.GroupName).HasMaxLength(10);
            builder.HasIndex(x => x.GroupName).IsUnique();
        }
    }
}
