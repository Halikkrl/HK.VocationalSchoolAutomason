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
    public class WeeklyLessonHoursConfiguration : IEntityTypeConfiguration<WeeklyLessonHours>
    {
        public void Configure(EntityTypeBuilder<WeeklyLessonHours> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.StartTime).HasColumnType("time");
            builder.Property(x => x.EndTime).HasColumnType("time");
        }
    }
}
