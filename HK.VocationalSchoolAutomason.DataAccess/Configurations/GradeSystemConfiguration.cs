using HK.VocationalSchoolAutomason.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.Configurations
{
    public class GradeSystemConfiguration : IEntityTypeConfiguration<GradeSystem>
    {
        public void Configure(EntityTypeBuilder<GradeSystem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.StudentMajorLevelGroup).WithMany(x => x.GradeSystems).HasForeignKey(x => x.StudentMajorLevelGroupId);
            builder.HasOne(x => x.Course).WithMany(x => x.GradeSystems).HasForeignKey(x => x.CourseId);
            builder.HasIndex(x => x.StudentMajorLevelGroupId).IsUnique();

            builder.Property(x => x.NoteOne).HasColumnType("decimal(5,2)");
            //builder.Property(x => x.NoteOne).IsRequired(false);
            builder.Property(x => x.NoteTwo).HasColumnType("decimal(5,2)");
            //builder.Property(x => x.NoteTwo).IsRequired(false);
            builder.Property(x => x.NoteThree).HasColumnType("decimal(5,2)");
            //builder.Property(x => x.NoteThree).IsRequired(false);
            builder.Property(x => x.OralGrade).HasColumnType("decimal(5,2)");
            //builder.Property(x => x.OralGrade).IsRequired(false);
            builder.Property(x => x.Status).HasColumnType("decimal(5,2)");
            //builder.Property(x => x.Status).IsRequired(false);
        }
    }
}
