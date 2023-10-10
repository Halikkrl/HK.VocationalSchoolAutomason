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
    public class ClassLessonConfiguration : IEntityTypeConfiguration<ClassLessons>
    {
        public void Configure(EntityTypeBuilder<ClassLessons> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Course).WithMany(x => x.ClassLessons).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.LevelGruopMojor).WithMany(x => x.ClassLessons).HasForeignKey(x => x.LGMId);
        }
    }
}
