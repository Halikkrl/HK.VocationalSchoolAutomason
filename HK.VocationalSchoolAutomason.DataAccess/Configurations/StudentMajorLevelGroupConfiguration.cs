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
    public class StudentMajorLevelGroupConfiguration : IEntityTypeConfiguration<StudentMajorLevelGroup>
    {
        public void Configure(EntityTypeBuilder<StudentMajorLevelGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.TotalContinuity).HasColumnType("decimal(3,2)");

            builder.HasOne(x => x.Students).WithMany(x => x.StudentMajorLevelGroups).HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.LevelGruopMojor).WithMany(x => x.StudentMajorLevelGroups).HasForeignKey(x => x.MajorLevelGroupId);
            builder.HasOne(x => x.Semester).WithMany(x => x.StudentMajorLevelGroups).HasForeignKey(x => x.SemesterId);

            builder.HasIndex(x => new {x.StudentId, x.MajorLevelGroupId,x.SemesterId}).IsUnique();
        }
    }
}
